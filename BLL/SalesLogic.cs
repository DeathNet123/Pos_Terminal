using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SalesLogic
    {
        public int GetLastId()
        {
            SalesDal dal = new SalesDal();
            return dal.LastId();
        }

        public void MakeSale(List<ItemDto> lineitems, SaleDto dto, CustomerDto customer, decimal amount)
        {
            SalesDal sdal = new SalesDal();
            CustomerDal cdal = new CustomerDal();

            if (customer.GetSalesLimit < amount)
            {
                Console.WriteLine("Sales Limit Exceeded for the Customer");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sale FAILED...");
                Console.WriteLine("Press Any key To Continue");
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            //Increasing the Payable Amount By Customer..
            customer.GetAmount += amount;
            cdal.UpdateCustomer(customer);

            sdal.WriteSale(dto); //Writing sale
            
            //Writing the Line items
            foreach(ItemDto item in lineitems) 
            {
                LineItemDto lineItemDto = new LineItemDto() {
                    OrderId = dto.OrderId,
                    ItemId = item.Id,
                    Quantity = item.Quantity,
                    Amount = item.Price * item.Quantity
                };

                sdal.WriteLineItem(lineItemDto);
            }

            Console.WriteLine("Sales Recorded Press Any key to Continue");
            Console.ReadKey();
        }
    }
}
