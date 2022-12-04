using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class ItemsLogic
    {
        public void AddItems(ItemDto item)
        {
            ItemDal dal = new ItemDal();
            Console.WriteLine(item);
            Console.WriteLine("Do you want to Add this to Items Y/N > ");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char key = char.ToLower(keyInfo.KeyChar);
            switch (key)
            {
                case 'y':
                    dal.WriteItems(item);
                    Console.WriteLine("Item has been added successfully");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
            
        }
        
        public void UpdateItems(ItemDto item, ItemDto newItem) 
        {
            ItemDal dal = new ItemDal();

            if(newItem.Description != "")
            {
                item.Description = newItem.Description;
            }

            if(newItem.Price != 0)
            {
                item.Price = newItem.Price;
            }

            if(newItem.Quantity != -1) 
            {
                item.Quantity = newItem.Quantity;
            }

            Console.WriteLine(item);
            Console.WriteLine("Your Modified Record Y/N > ");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            char key = char.ToLower(keyInfo.KeyChar);
            switch (key)
            {
                case 'y':
                    dal.UpdateItems(item);
                    Console.WriteLine("Item has been Modified successfully");
                    Console.Write("Press any key to continue");
                    Console.ReadKey();
                    break;
                default:
                    break;
            }

        }

        public ItemDto getRecord(int id)
        {
            ItemDal dal = new ItemDal();
            return dal.getRecord(id);
        }
        public int GetLastId()
        {
            ItemDal dal = new ItemDal();
            return dal.LastId();

        }
    
        public List<ItemDto> FindItems(ItemDto criteria)
        {
            ItemDal dal = new ItemDal();
            return dal.FindItems(criteria);
        }

        public void RemoveItem(int id)
        {
            SalesDal sdal = new SalesDal();
            LineItemDto dto = sdal.getRecordItem(id);

            if (dto.LineId != -1) 
            {
                Console.WriteLine("Customer is associated with sale");
                Console.Write("Press any key to continue");
                Console.ReadKey();
                return;
            }

            ItemDal cdal = new ItemDal();
            ItemDto cus = cdal.getRecord(id);
            Console.WriteLine(cus);
            Console.WriteLine("Do you want to remove this Item Y/N");
            ConsoleKeyInfo keyinfo = Console.ReadKey(false);
            char key = char.ToLower(keyinfo.KeyChar);
            switch (key)
            {
                case 'y':
                    cdal.RemoveItem(id);
                    Console.WriteLine("Item has been removed successfully");
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
