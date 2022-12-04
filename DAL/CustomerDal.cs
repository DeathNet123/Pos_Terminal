using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class CustomerDal : BaseDal
    {
        public void UpdateCustomer(CustomerDto Customer)
        {
            String query = "Update Customer set Name = @na, Address = @ad, Phone = @ph, Email = @em, Amount = @am, SalesLimit = @sa where CustomerId = @i";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("i", Customer.GetCustomerId));
            list.Add(new SqlParameter("na", Customer.GetName));
            list.Add(new SqlParameter("ad", Customer.GetAddress));
            list.Add(new SqlParameter("ph", Customer.GetPhone));
            list.Add(new SqlParameter("em", Customer.GetEmail));
            list.Add(new SqlParameter("am", Customer.GetAmount));
            list.Add(new SqlParameter("sa", Customer.GetSalesLimit));
            
            write(query, list);
        }

        public void WriteCustomer(CustomerDto Customer)
        {
            String query = "Insert into Customer Values(@na, @ad, @ph, @em, @am, @sa)";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("na", Customer.GetName));
            list.Add(new SqlParameter("ad", Customer.GetAddress));
            list.Add(new SqlParameter("ph", Customer.GetPhone));
            list.Add(new SqlParameter("em", Customer.GetEmail));
            list.Add(new SqlParameter("am", Customer.GetAmount));
            list.Add(new SqlParameter("sa", Customer.GetSalesLimit));
            
            write(query, list);
        }

        public int LastId()
        {
            String query = "select top 1 CustomerId from Customer order by CustomerId desc";
            List<SqlParameter> list = new List<SqlParameter>();
            
            List<Object[]> id = read(query, list);
            
            if (id.Count == 0) return 0;
            
            return (int)id[0][0];
        }

        public CustomerDto getRecord(int id)
        {
            
            List<SqlParameter> list = new List<SqlParameter>();
            
            String query = "select * from Customer where CustomerId = @i";
            list.Add(new SqlParameter("i", id));
            List<Object[]> record = read(query, list);
            
            if (record.Count == 0) return new CustomerDto() { GetCustomerId = -1 };
            
            return new CustomerDto()
            {
                GetCustomerId = (int)record[0][0],
                GetName = (string)record[0][1],
                GetAddress = (string)record[0][2],
                GetPhone = (string)record[0][3],
                GetEmail = (string)record[0][4],
                GetAmount = Convert.ToDecimal((double)record[0][5]),
                GetSalesLimit = Convert.ToDecimal((double)record[0][6])
            };
        }

        public List<CustomerDto> FindCustomer(CustomerDto criteria)
        {
            List<CustomerDto> customers = new List<CustomerDto>();
            List<SqlParameter> list = new List<SqlParameter>();
            
            String query = $"Select * from Customer where {criteria.Criteria()}";
            list.Add(new SqlParameter("na", criteria.GetName ?? ""));
            list.Add(new SqlParameter("ad", criteria.GetAddress ?? ""));
            list.Add(new SqlParameter("ph", criteria.GetPhone ?? ""));
            list.Add(new SqlParameter("em", criteria.GetEmail ?? "" ));
            list.Add(new SqlParameter("am", criteria.GetAmount ?? 0));
            list.Add(new SqlParameter("sa", criteria.GetSalesLimit ?? 0));
            list.Add(new SqlParameter("cu", criteria.GetCustomerId?? 0));

            List<Object[]> record = read(query, list);
            for (int idx = 0; idx < record.Count; idx++)
            {
                CustomerDto temp = new CustomerDto()
                {
                    GetCustomerId = (int)record[idx][0],
                    GetName = (string)record[idx][1],
                    GetAddress = (string)record[idx][2],
                    GetPhone = (string)record[idx][3],
                    GetEmail = (string)record[idx][4],
                    GetAmount = Convert.ToDecimal((double)record[idx][5]),
                    GetSalesLimit = Convert.ToDecimal((double)record[idx][6])
                };
                customers.Add(temp);
            }
            
            return customers;
        }

        public void RemoveCustomer(int id)
        {
            string query = "delete from Customer where CustomerId = @i";
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("i", id));

            write(query, list);
        }
    }
}
