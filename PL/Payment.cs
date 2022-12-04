using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Payment
    {
        public static void MakePayment()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("|                            Payment                                      |");
            Console.WriteLine("|                                                                         |");
            Console.WriteLine("---------------------------------------------------------------------------");
            PaymentLogic paymentLogic = new PaymentLogic();

            int id = 0;
            Console.Write("Enter the Sale ID> ");
            try
            {
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Enter Valid Sale Id");
                Console.WriteLine("Press Any Key to Continue");
                Console.ReadKey();
                return;
            }
            paymentLogic.MakePayment(id);

        }
    }
}
