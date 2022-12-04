using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class CutomerMenu
    {
        public static bool CustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            Customer Menu                                |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("1 - Add new Customer");
            Console.WriteLine("2 - Update Customer Details");
            Console.WriteLine("3 - Find Customer");
            Console.WriteLine("4 - Remove Existing Customer");
            Console.WriteLine("5 - Back to Main Menu");
            Console.Write("> ");
            String? value = Console.ReadLine();
            switch (value)
            {
                case "1":
                    AddCustomer();
                    break;
                case "2":
                    UpdateCustomer();
                    break;
                case "3":
                    FindCustomer();
                    break;
                case "4":
                    RemoveCustomer();
                    break;
                case "5":
                    return true;
                default:
                    Console.WriteLine("Enter the Valid Choice. Press Enter to Try Again");
                    Console.Write("> ");
                    Console.ReadKey();
                    break;
            }
            return false;
        }

        public static void AddCustomer()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Add Customer Data                               |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            CustomersLogic logic = new CustomersLogic();
            int last_id = logic.GetLastId();
            decimal price;

            Console.Write("Enter the Name> ");
            String name = Console.ReadLine();
            name = name.ToLower();

            Console.Write("Enter the Address> ");
            String add = Console.ReadLine();
            add = add.ToLower();

            Console.Write("Enter the Phone> ");
            String phone = Console.ReadLine();
            phone = phone.ToLower();

            Console.Write("Enter the Email> ");
            String email = Console.ReadLine();
            
            Console.Write("Enter Sales Limit> ");
            try
            {
                price = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Number for the Sales Limit");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            CustomerDto dto = new CustomerDto()
            {
                GetCustomerId = last_id + 1,
                GetName = name,
                GetAddress = add,
                GetPhone = phone,
                GetEmail = email,
                GetSalesLimit = price
            };

            logic.AddCustomer(dto);
        }

        public static void UpdateCustomer()
        {
            CustomersLogic logic = new CustomersLogic();
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Update Customer                                 |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            Console.Write("Enter CustomerID> ");
            int id;
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter valid ID");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            CustomerDto dto = logic.getRecord(id); //get Record if not found exit
            if (dto.GetCustomerId == -1)
            {
                Console.WriteLine("Record Not Found");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            Console.WriteLine(dto);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Data into fields you want to modify. Leave other field blank");
            Console.ForegroundColor = ConsoleColor.White;
            decimal price;
            decimal topay;

            Console.Write("Enter the Name> ");
            String name = Console.ReadLine();
            name = name.ToLower();

            Console.Write("Enter the Address> ");
            String add = Console.ReadLine();
            add = add.ToLower();

            Console.Write("Enter the Phone> ");
            String phone = Console.ReadLine();
            phone = phone.ToLower();

            Console.Write("Enter the Email> ");
            String email = Console.ReadLine();

            Console.Write("Enter AmountPayable> ");
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "0";
                topay = Convert.ToDecimal(temp);
            }
            catch
            {
                Console.WriteLine("Enter Number for the Dues");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Sales Limit> ");
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "0";
                price = Convert.ToDecimal(temp);
            }
            catch
            {
                Console.WriteLine("Enter Number for the Sales Limit");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            CustomerDto newdto = new CustomerDto()
            {
                GetName = name,
                GetAddress = add,
                GetPhone = phone,
                GetEmail = email,
                GetAmount= topay,
                GetSalesLimit = price
            };

            logic.UpdateCustomer(dto, newdto);
        }

        public static void FindCustomer()
        {
            CustomersLogic logic = new CustomersLogic();
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Find Customer                                   |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Data into fields you want in Search Criteria. Leave other field blank");
            Console.ForegroundColor = ConsoleColor.White;
            decimal price;
            decimal topay;

            Console.Write("Enter CustomerID> ");
            int id;
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "-1";
                id = Convert.ToInt32(temp);
            }
            catch
            {
                Console.WriteLine("Enter valid ID");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter the Name> ");
            String name = Console.ReadLine();
            name = name.ToLower();

            Console.Write("Enter the Address> ");
            String add = Console.ReadLine();
            add = add.ToLower();

            Console.Write("Enter the Phone> ");
            String phone = Console.ReadLine();
            phone = phone.ToLower();

            Console.Write("Enter the Email> ");
            String email = Console.ReadLine();

            Console.Write("Enter AmountPayable> ");
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "-1";
                topay = Convert.ToDecimal(temp);
            }
            catch
            {
                Console.WriteLine("Enter Number for the Dues");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Sales Limit> ");
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "-1";
                price = Convert.ToDecimal(temp);
            }
            catch
            {
                Console.WriteLine("Enter Number for the Sales Limit");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            CustomerDto newdto = new CustomerDto()
            {
                GetCustomerId = id,
                GetName = name,
                GetAddress = add,
                GetPhone = phone,
                GetEmail = email,
                GetAmount = topay,
                GetSalesLimit = price
            };
            List<CustomerDto> result = logic.FindCustomer(newdto);
            PrintTable(result);
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();
        }

        public static void RemoveCustomer()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Remove Customer                                 |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            int id;
            Console.Write("Enter the ID >");
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Valid Id");
                Console.Write("Press Any Key to Continue");
                Console.ReadKey(true);
                return;
            }

            CustomersLogic logic= new CustomersLogic();
            logic.RemoveCustomer(id);
            
        }

        public static void PrintTable(List<CustomerDto> list)
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                           |");
            Console.WriteLine("|                                        Search Result                                                      |");
            Console.WriteLine("|                                                                                                           |");
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format(format: "|{0, -10}|{1, -25}|{2, -20}|{3, -11}|{4, -7}|", "CustomerId", " Name", " Email", " Phone", " SalesLimit"));
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            TextInfo ti = new CultureInfo("en-US").TextInfo;
            foreach (CustomerDto customer in list)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format(format: "|{0, -10}| {1, -25}| {2, -20}| {3, -11}| {4, -17}|", customer.GetCustomerId, ti.ToTitleCase(customer.GetName), $"{customer.GetEmail}", customer.GetPhone, $"{ customer.GetSalesLimit:C}"));
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
            }
        }
    }

}
