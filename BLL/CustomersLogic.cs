using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomersLogic
    {
        public void AddCustomer(CustomerDto customer)
        {
            CustomerDal dal = new CustomerDal();
            Console.WriteLine(customer);
            Console.WriteLine("Do you want to Add this to Customer to the DB Y/N > ");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char key = char.ToLower(keyInfo.KeyChar);
            switch (key)
            {
                case 'y':
                    dal.WriteCustomer(customer);
                    Console.WriteLine("Customer has been added successfully");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }

        }

        public void UpdateCustomer(CustomerDto customer, CustomerDto newCustomer)
        {
            CustomerDal dal = new CustomerDal();

            if (newCustomer.GetName != "")
            {
                customer.GetName = newCustomer.GetName;
            }
            if(newCustomer.GetAddress != "")
            {
                customer.GetAddress = newCustomer.GetAddress;
            }
            if(newCustomer.GetPhone != "")
            {
                customer.GetPhone= newCustomer.GetPhone;
            }
            if (newCustomer.GetEmail!= "")
            {
                customer.GetEmail = newCustomer.GetEmail;
            }
            if (newCustomer.GetAmount!= 0)
            {
                customer.GetAmount = newCustomer.GetAmount;
            }
            if(newCustomer.GetSalesLimit!= 0) 
            {
                customer.GetSalesLimit = newCustomer.GetSalesLimit;
            }

            Console.WriteLine(customer);
            Console.WriteLine("Your Modified Record Y/N > ");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char key = char.ToLower(keyInfo.KeyChar);
            switch (key)
            {
                case 'y':
                    dal.UpdateCustomer(customer);
                    Console.WriteLine("Customer Data has been Modified successfully");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }

        }

        public CustomerDto getRecord(int id)
        {
            CustomerDal dal = new CustomerDal();
            return dal.getRecord(id);
        }

        public int GetLastId()
        {
            ItemDal dal = new ItemDal();
            return dal.LastId();

        }

        public List<CustomerDto> FindCustomer(CustomerDto criteria)
        {
            CustomerDal dal = new CustomerDal();
            if (criteria.GetCustomerId == -1) criteria.GetCustomerId = null;
            if(criteria.GetName == "") criteria.GetName = null;
            if(criteria.GetAddress == "") criteria.GetAddress = null;
            if(criteria.GetEmail== "") criteria.GetEmail = null;
            if (criteria.GetPhone == "") criteria.GetPhone = null;
            if (criteria.GetAmount == -1) criteria.GetAmount = null;
            if (criteria.GetSalesLimit == -1) criteria.GetSalesLimit = null;

            return dal.FindCustomer(criteria);
        }

        public void RemoveCustomer(int id)
        {
            SalesDal sdal = new SalesDal();
            SaleDto dto = sdal.getRecordCustomer(id);

            if (dto.OrderId != -1)
            {
                Console.WriteLine("Customer is associated with sale");
                Console.Write("Press any key to continue");
                Console.ReadKey();
                return;
            }

            CustomerDal cdal = new CustomerDal();
            CustomerDto cus = cdal.getRecord(id);
            Console.WriteLine(cus);
            Console.WriteLine("Do you want to remove this customer Y/N");
            ConsoleKeyInfo keyinfo =  Console.ReadKey(false);
            char key = char.ToLower(keyinfo.KeyChar);
            switch (key)
            {
                case 'y':
                    cdal.RemoveCustomer(id);
                    Console.WriteLine("Customer has been Removed successfully");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Operation Aborted");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
            }

        }
    }
}
