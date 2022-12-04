using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class SalesPoint
    {
        public static void MakeSale()
        {
            List<ItemDto> lineitem = new List<ItemDto>();
            SalesLogic logic = new SalesLogic();
            SaleDto dto = new SaleDto();
            CustomerDto customer;

            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            Sales Point                                  |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            dto.OrderId = logic.GetLastId() + 1; 
            Console.WriteLine($"Sales ID {dto.OrderId}");

            dto.Date = DateTime.Now;
            Console.WriteLine($"Sale Date {dto.Date.ToString("yyyy/MM/dd")}");

            //Getting Customer Id.. and checking if it is valid
            try
            {
                Console.Write("Customer ID> ");
                dto.CustomerId = Convert.ToInt32(Console.ReadLine());
                CustomersLogic customersLogic = new CustomersLogic();
                customer = customersLogic.getRecord(dto.CustomerId);
                if (customer.GetCustomerId == -1) throw new Exception();
            }
            catch
            {
                Console.WriteLine("Enter Valid Customer ID");
                Console.WriteLine("Press Any Key To Try Again");
                Console.ReadKey();
                return;
            }

            AddLineItem(lineitem); //get first item..
            bool hopon = true;
            do
            {
                Console.WriteLine("1 - Enter New Line Item");
                Console.WriteLine("2 - End Sale");
                Console.WriteLine("3 - Remove the Line Item");
                Console.WriteLine("4 - Cancel Sale");

                ConsoleKeyInfo keyinfo = Console.ReadKey(true);
                char key = keyinfo.KeyChar;
                switch(key)
                {
                    case '2':
                        hopon = false;
                        break;
                    case '1':
                        AddLineItem(lineitem);
                        break;
                    case '3':
                        RemoveLineItem(lineitem);
                        break;
                    case '4':
                        Console.WriteLine("Sale has been Canceled");
                        Console.WriteLine("Press Any Key to Continue");
                        Console.ReadKey();
                        return;
                }
            }while(hopon);

            decimal subtotal = PrintSales(lineitem, dto, customer);
            logic.MakeSale(lineitem, dto, customer, subtotal);
           
            return;
        }

        public static void AddLineItem(List<ItemDto> lineitem)
        {
            ItemsLogic logic = new ItemsLogic();
            ItemDto dto;

            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            LineItems                                    |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            //Get the Item Id and check if it is valid or not...
            Console.Write("Enter ItemId> ");
            try
            {
                dto  = logic.getRecord(Convert.ToInt32(Console.ReadLine()));
                if(dto.Id == -1) throw new Exception();
            }
            catch
            {
                Console.WriteLine("Enter Valid Item ID");
                Console.WriteLine("Press Any Key To Try Again");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Decscription : {dto.Description} Price : {dto.Price}");

            Console.Write("Enter Qunatity> ");
            try
            {
                dto.Quantity = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter No for Quantity");
                Console.WriteLine("Press Any Key To Try Again");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"SubTotal : {dto.Quantity * dto.Price}");

            //Once everthing is ready add it to temporary list..
            lineitem.Add(dto);
        }

        public static void RemoveLineItem(List<ItemDto> lineitems)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            Remove LineItems                             |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            int id;
            Console.Write("Enter the Id> ");
            try
            {
                id = Convert.ToInt32(Console.ReadLine()); //should have made the function for the conversion checks lol but now i am almost done..

            }
            catch
            {
                Console.WriteLine("Enter Valid ID");
                Console.WriteLine("Press Any Key To Try Again");
                Console.ReadKey();
                return;
            }
            
            for(int idx = 0; idx < lineitems.Count; idx++)
            {
                if (lineitems[idx].Id == id)
                {
                    lineitems.RemoveAt(idx);
                    Console.WriteLine("Item Removed");
                    Console.WriteLine("Press Any Key to Continue");
                    Console.ReadKey(true);
                    return;
                }
            }

            //if the loop is done it means item is not found in list...

            Console.WriteLine("Item not found in lineitems");
            Console.WriteLine("Press Any key to Continue");
            Console.ReadKey();
            return;
        }
        
        public static decimal PrintSales(List<ItemDto> lineitems, SaleDto dto, CustomerDto customer)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            Result                                       |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            TextInfo ti = new CultureInfo("en-US").TextInfo;
            //46 Spaces here
            Console.WriteLine($"SalesID: {dto.OrderId}                                              CustomerID: {customer.GetCustomerId}");
            Console.WriteLine($"SalesDate: {dto.Date.ToString("yyyy/MM/dd")}                                              CustomerName: {ti.ToTitleCase(customer.GetName ?? "NULL")}");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine(format:"{0, 9}|{1, 39}|{2, 9}|{3, 13}|", "ItemId", "Description", "Quantity", "Amount");
            Console.WriteLine("---------------------------------------------------------------------------");
            decimal subtotal = 0m;
            foreach(ItemDto item in lineitems)
            {
                subtotal += item.Quantity * item.Price;
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine(format: "{0, 9}|{1, 39}|{2, 9}|{3, 13}|", item.Id, item.Description, item.Quantity, item.Price * item.Quantity);
                Console.WriteLine("---------------------------------------------------------------------------");
                
            }

            Console.WriteLine($"Total Sales : {subtotal}");
            Console.WriteLine("---------------------------------------------------------------------------");
            return subtotal;
        }
    }
}
/*I have assumed we don't have to manage the stock level in this sale system and we are assuming that we have unlmited supply of
 * items.. reason for this assumption is it's no where mention in doc of assignment*/