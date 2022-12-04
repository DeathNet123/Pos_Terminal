using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PaymentLogic
    {
        public void MakePayment(int id)
        {
            //Get sales record if not found print error and exit..
            SalesDal salesDal= new SalesDal();
            SaleDto sale = salesDal.getRecordOrder(id);
            if(sale.OrderId == -1)
            {
                Console.WriteLine("No Sales Record Found");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }
            if(sale.Status.Equals("Paid"))
            {
                Console.WriteLine("Alread Paid");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            //Fetch Customer...
            CustomerDal customerDal= new CustomerDal();
            CustomerDto customerDto = customerDal.getRecord(sale.CustomerId);

            //Getting related items
            List<LineItemDto> lineItems = salesDal.ReadLineItem(sale.OrderId);
            decimal total = 0;
            foreach(LineItemDto lineItem in lineItems)
            {
                total += lineItem.Amount;
            }

            //Getting Paid Amount by reading the Reciepts
            List<ReDto> reciepts = salesDal.ReadReciept(sale.OrderId);
            decimal paid = 0;
            foreach(ReDto reciept in reciepts)
            {
                paid = reciept.Amount;
            }
            
            decimal remain = total - paid;
            Console.WriteLine($"Sale ID : {sale.OrderId}\nCustomer Name : {customerDto.GetName}\nTotal Sales : {total}\nPaid : {paid}");
            Console.WriteLine($"Remaining Amount : {remain}");

            Console.Write("Enter Amount to Pay> ");

            decimal fees;
            try
            {
                fees = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Valid Amount");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            if(fees > remain)
            {
                Console.WriteLine($"Excess Amount is has been Entered Change will be {fees - remain}");
                Console.WriteLine($"Reciept of {remain:C} will be Generated");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey(true);
                fees = remain;
            }

            if(fees == remain)
            {
                salesDal.ChangeStatus(sale.OrderId, "Paid");
            }

            //Update the Customer Date to Be Paid..
            remain = remain - fees;
            customerDto.GetAmount = remain;
            customerDal.UpdateCustomer(customerDto);

            ReDto reDto = new ReDto() 
            {
               RecieptDate = DateTime.Now,
               OrderId = sale.OrderId,
               Amount = fees,
            };
            salesDal.WriteReciept(reDto);

            Console.WriteLine("Payment Completed");
            Console.WriteLine("Press Any Key to Contine");
            Console.ReadKey();
        }

    }
}
