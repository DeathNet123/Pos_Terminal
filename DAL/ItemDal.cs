using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class ItemDal : BaseDal
    {
        public void UpdateItems(ItemDto item)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            
            String query = "update Item set Description = @d, Price = @p, Quantity = @q, CreationDate = @c where ItemId = @i";
            list.Add(new SqlParameter("i", item.Id));
            list.Add(new SqlParameter("d", item.Description));
            list.Add(new SqlParameter("p", item.Price));
            list.Add(new SqlParameter("q", item.Quantity));
            list.Add(new SqlParameter("c", item.CreationDate.ToString("yyyy/MM/dd")));
            
            write(query, list);
        }
        
        public void WriteItems(ItemDto item)
        {
            String query = "Insert into Item Values(@d, @p, @q, @c)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("d", item.Description));
            list.Add(new SqlParameter("p", item.Price));
            list.Add(new SqlParameter("q", item.Quantity));
            list.Add(new SqlParameter("c", item.CreationDate.ToString("yyyy/MM/dd")));
            
            write(query, list);
        }

        public int LastId()
        {
            String query = "select top 1 ItemId from Item order by ItemId desc";
            List<SqlParameter> list = new List<SqlParameter>();
            
            List<Object[]> id = read(query, list);
            
            if(id.Count == 0) return 0;
            
            return (int)id[0][0];
        }

        public ItemDto getRecord(int id)
        {
            String query = "select * from Item where ItemId = @i";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("i", id));
            
            List<Object[]> record = read(query, list);
            
            if(record.Count == 0) return new ItemDto() { Id = -1};
            
            return new ItemDto()
            {
                Id = (int)record[0][0],
                Description = (string)record[0][1],
                Price = Convert.ToDecimal((double)record[0][2]),
                Quantity = (int)record[0][3],
                CreationDate= (DateTime)record[0][4]
            };
        }

        public List<ItemDto> FindItems(ItemDto criteria)
        {
            List<ItemDto> items = new List<ItemDto>();
            List<SqlParameter> sqlParameters= new List<SqlParameter>();
            
            String query = $"Select * from Item where {criteria.Criteria()}";
            sqlParameters.Add(new SqlParameter("i", criteria.Id));
            sqlParameters.Add(new SqlParameter("d", criteria.Description));
            sqlParameters.Add(new SqlParameter("p", criteria.Price));
            sqlParameters.Add(new SqlParameter("q", criteria.Quantity));
            sqlParameters.Add(new SqlParameter("c", criteria.CreationDate.ToString("yyyy/MM/dd")));
            
            List<Object[]> list = read(query, sqlParameters);
            
            for(int idx = 0; idx < list.Count; idx++)
            {
                ItemDto temp = new ItemDto()
                {
                    Id = (int)list[idx][0],
                    Description = (string)list[idx][1],
                    Price = Convert.ToDecimal((double)list[idx][2]),
                    Quantity = (int)list[idx][3],
                    CreationDate = (DateTime)list[idx][4]
                };
                items.Add(temp);
            }
            return items;
        }

        public void RemoveItem(int id)
        {
            string query = "delete from Item where ItemId = @i";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("i", id));

            write(query, list);
        }
    }
}
