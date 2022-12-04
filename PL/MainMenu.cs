using BLL;
using DTO;
namespace PL
{
    public class MainMenu
    {
        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            Main Menu                                    |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("1 - Manage Items");
            Console.WriteLine("2 - Manage Customers");
            Console.WriteLine("3 - Make New Sale");
            Console.WriteLine("4 - Make New Payment");
            Console.WriteLine("5 - Exit");
            Console.Write("> ");
            String? value = Console.ReadLine();
            switch (value)
            {
                case "1":
                    MainMenu.ManageItems();
                    break;
                case "2":
                    MainMenu.ManageCustomers();
                    break;
                case "3":
                    MainMenu.MakeSale();
                    break;
                case "4":
                    MainMenu.MakePayment();
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Enter the Valid Choice. Press Enter to Try Again");
                    Console.Write("> ");
                    Console.ReadKey();
                    break;
            }
        }
        
        public static void MakePayment()
        {
            Payment.MakePayment();
        }
        
        public static void MakeSale()
        {
            SalesPoint.MakeSale();
        }

        public static void ManageCustomers()
        {
            while(true)
            {
                if(CutomerMenu.CustomerMenu()) return;
            }
        }

        public static void ManageItems()
        {
            while (true)
            {
                if (ItemMenu.ItemsMenu()) return;
            }
        }

    }
}