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
    public class ItemMenu
    { 
        public static bool ItemsMenu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            Items Menu                                   |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("1 - Add new Item");
            Console.WriteLine("2 - Update Item Details");
            Console.WriteLine("3 - Find Items");
            Console.WriteLine("4 - Remove Existing Item");
            Console.WriteLine("5 - Back to Main Menu");
            Console.Write("> ");
            String? value = Console.ReadLine();
            switch (value)
            {
                case "1":
                    AddItems();
                    break;
                case "2":
                    UpdateItems();
                    break;
                case "3":
                    FindItems();
                    break;
                case "4":
                    RemoveItems();
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

        public static void AddItems()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Add Item Data                                   |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");

            ItemsLogic logic = new ItemsLogic();
            int last_id = logic.GetLastId();
            decimal price;
            int quantity;

            Console.Write("Enter the Description> ");
            String desc = Console.ReadLine();
            desc = desc.ToLower();

            Console.Write("Enter Price> ");
            try 
            {
                 price = Convert.ToDecimal(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Number for the Price");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }
               
            Console.Write("Enter the Quantity> ");
            try
            {
                quantity = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Number for the Quantity");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            ItemDto dto = new ItemDto() {
                Id = last_id + 1,
                Description = desc,
                Price = price,
                Quantity = quantity
            };

            logic.AddItems(dto);
        }

        public static void UpdateItems() 
        {
            Console.Clear();
            ItemsLogic logic = new ItemsLogic();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Update Item                                     |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");
            
            Console.Write("Enter ID> ");
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
            
            ItemDto dto = logic.getRecord(id); //get Record if not found exit
            if(dto.Id == -1)
            {
                Console.WriteLine("Record Not Found");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }
            
            Console.WriteLine(dto);
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine("Enter the Data into fields you want to modify. Leave other field blank");
            Console.ForegroundColor = ConsoleColor.White;
            decimal price;
            int quantity;

            Console.Write("Enter the Description> ");
            String desc = Console.ReadLine();
            desc = desc.ToLower();

            Console.Write("Enter Price> ");
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "0";
                price = Convert.ToDecimal(temp);
            }
            catch
            {
                Console.WriteLine("Enter Number for the Price");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
                return;
            }

            Console.Write("Enter the Quantity> ");
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "-1";
                quantity = Convert.ToInt32(temp);
            }
            catch
            {
                Console.WriteLine("Enter Number for the Quantity");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
                return;
            }

            ItemDto newdto = new ItemDto()
            {
                Id = dto.Id,
                Description = desc,
                Price = price,
                Quantity = quantity
            };
            logic.UpdateItems(dto, newdto);
        }

        public static void FindItems() 
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Find Item                                       |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter the Data into fields you want in search criteria. Leave other field blank");
            Console.ForegroundColor = ConsoleColor.White;
            decimal price;
            int quantity;
            int id;
            String desc;
            DateTime date;

            Console.Write("Enter ID> ");
            
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

            Console.Write("Enter the Description> ");
            desc = Console.ReadLine();
            desc = desc.ToLower();

            Console.Write("Enter Price> ");
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "0";
                price = Convert.ToDecimal(temp);
            }
            catch
            {
                Console.WriteLine("Enter Number for the Price");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            
            Console.Write("Enter the Quantity> ");
            try
            {
                String temp = Console.ReadLine();
                if (temp == "") temp = "-1";
                quantity = Convert.ToInt32(temp);
            }
            catch
            {
                Console.WriteLine("Enter Number for the Quantity");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter the Creation Date in numeric format e.g: (2022-Dec-02) yyyy-MM-dd (2022-12-02) > ");
            String dates = Console.ReadLine();
            try
            {
                String[] list = dates.Split("-");
                if(dates != "")
                    date = new DateTime(Convert.ToInt32(list[0]), Convert.ToInt32(list[1]), Convert.ToInt32(list[2]));
                else
                    date = new DateTime();
            }
            catch
            {
                Console.WriteLine("Enter Valid Date Format");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }

            ItemDto dto = new ItemDto() {
                Id = id,
                Description = desc,
                Price = price,
                Quantity = quantity,
                CreationDate = date
            };

            ItemsLogic logic = new ItemsLogic();
            List<ItemDto> result = logic.FindItems(dto);
            PrintTable(result);
            Console.WriteLine("Press Any Key to Continue");
            Console.ReadKey();
        }

        public static void RemoveItems() 
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Remove Item                                     |");
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

            ItemsLogic logic = new ItemsLogic();
            logic.RemoveItem(id);
        }
    
        public static void PrintTable(List<ItemDto> list)
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                         Search Result                                   |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(String.Format(format:"|{0, -5}|{1, -25}|{2, -7}|{3, -10}|{4, -17}|", "ItemId", " Description", " Price", " Quantity", " CreationDate"));
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine("---------------------------------------------------------------------------");
            TextInfo ti = new CultureInfo("en-US").TextInfo;
            foreach (ItemDto item in list)
            {
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine(String.Format(format: "|{0, -5}| {1, -25}| {2, -7}| {3, -10}| {4, -17}|", item.Id, ti.ToTitleCase(item.Description), $"{item.Price:C}", item.Quantity, item.CreationDate.ToString("yyyy/MM/dd")));
                Console.WriteLine("---------------------------------------------------------------------------");
            }
        }
    }
}
