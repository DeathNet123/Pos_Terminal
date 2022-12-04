using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SalesDal: BaseDal
    {
        public void WriteSale(SaleDto sale)
        {
            List<SqlParameter> sqlParameters= new List<SqlParameter>();
            String query = "INSERT INTO Sale VALUES(@c, @d, @s)";
            sqlParameters.Add(new SqlParameter("c", sale.CustomerId));
            sqlParameters.Add(new SqlParameter("d", sale.Date.ToString("yyyy/MM/dd")));
            sqlParameters.Add(new SqlParameter("s", sale.Status));

            write(query, sqlParameters);
        }

        public int LastId()
        {
            String query = "select top 1 OrderId from Sale order by OrderId desc";
            List<SqlParameter> list = new List<SqlParameter>();

            List<Object[]> id = read(query, list);

            if (id.Count == 0) return 0;

            return (int)id[0][0];
        }

        public List<SaleDto> ReadSale()
        {
            List<SaleDto> sales = new List<SaleDto>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            String query = "Select * from Sale";

            List<Object[]> list = read(query, sqlParameters);

            foreach (Object[] listItem in list)
            {
                SaleDto temp = new SaleDto()
                {
                    OrderId = (int)listItem[0],
                    CustomerId = (int)listItem[1],
                    Date = (DateTime)listItem[2],
                    Status = (String)listItem[3]
                };
                sales.Add(temp);
            }
            return sales;
        }

        public SaleDto getRecordOrder(int id)
        {
            String query = "select * from Sale where OrderId = @o";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("o", id));

            List<Object[]> record = read(query, list);

            if (record.Count == 0) return new SaleDto() { OrderId = -1 };

            return new SaleDto()
            {
                OrderId = (int)record[0][0],
                CustomerId = (int)record[0][1],
                Date = (DateTime)record[0][2],
                Status = (String)record[0][3],  
            };
        }
        
        public void WriteLineItem(LineItemDto dto)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            String query = "INSERT INTO SaleLineItem VALUES(@o, @i, @q, @a)";
            sqlParameters.Add(new SqlParameter("o", dto.OrderId));
            sqlParameters.Add(new SqlParameter("i", dto.ItemId));
            sqlParameters.Add(new SqlParameter("q", dto.Quantity));
            sqlParameters.Add(new SqlParameter("a", dto.Amount));

            write(query, sqlParameters);
        }
        
        public SaleDto getRecordCustomer(int id) 
        {
            String query = "select * from Sale where CustomerId = @o";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("o", id));

            List<Object[]> record = read(query, list);

            if (record.Count == 0) return new SaleDto() { OrderId = -1 };

            return new SaleDto()
            {
                OrderId = (int)record[0][0],
                CustomerId = (int)record[0][1],
                Date = (DateTime)record[0][2],
                Status = (String)record[0][3],
            };
        }

        public LineItemDto getRecordItem(int id)
        {
            String query = "select * from SaleLineItem where ItemId = @o";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("o", id));

            List<Object[]> record = read(query, list);

            if (record.Count == 0) return new LineItemDto() { LineId = -1 };

            return new LineItemDto()
            {
                LineId = (int)record[0][0],
                OrderId = (int)record[0][1],
                ItemId = (int)record[0][2],
                Quantity = (int)record[0][3],
                Amount = Convert.ToDecimal(record[0][4]),
            };
        }

        public List<LineItemDto> ReadLineItem(int id)
        {
            List<LineItemDto> sales = new List<LineItemDto>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            String query = "Select * from SaleLineItem where OrderId = @o";
            sqlParameters.Add(new SqlParameter("o", id));

            List<Object[]> list = read(query, sqlParameters);

            foreach (Object[] listItem in list)
            {
                LineItemDto temp = new LineItemDto()
                {
                    LineId = (int)listItem[0],
                    OrderId = (int)listItem[1],
                    ItemId = (int)listItem[2],
                    Quantity = (int)listItem[3],
                    Amount = Convert.ToDecimal(listItem[4])
                };
                sales.Add(temp);
            }
            return sales;
        }

        public List<ReDto> ReadReciept(int id)
        {
            List<ReDto> sales = new List<ReDto>();
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            String query = "Select * from Receipt where OrderId = @o";
            sqlParameters.Add(new SqlParameter("o", id));

            List<Object[]> list = read(query, sqlParameters);

            foreach (Object[] listItem in list)
            {
                ReDto temp = new ReDto()
                {
                    RecieptNo = (int)listItem[0],
                    RecieptDate = (DateTime)listItem[1],
                    OrderId = (int)listItem[2],
                    Amount = Convert.ToDecimal(listItem[3])
                };
                sales.Add(temp);
            }
            return sales;
        }

        public void WriteReciept(ReDto sale)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            String query = "INSERT INTO Receipt VALUES(@d, @i, @a)";
            sqlParameters.Add(new SqlParameter("d", sale.RecieptDate.ToString("yyyy/MM/dd")));
            sqlParameters.Add(new SqlParameter("i", sale.OrderId));
            sqlParameters.Add(new SqlParameter("a", sale.Amount));

            write(query, sqlParameters);
        }

        public void ChangeStatus(int id, String status)
        {
            String query = "Update Sale Set Status = @s where OrderId = @i";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("s", status));
            list.Add(new SqlParameter("i", id));

            write(query, list);
        }
    }
        
}
