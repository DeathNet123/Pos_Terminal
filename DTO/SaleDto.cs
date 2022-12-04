using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SaleDto
    {
		private int orderid;

		public int OrderId
		{
			get { return orderid; }
			set { orderid = value; }
		}

		private int customerid;

		public int CustomerId
		{
			get { return customerid; }
			set { customerid = value; }
		}

		private DateTime date;

		public DateTime Date
		{
			get { return date; }
			set { date = value; }
		}

		private String status;

		public String Status
		{
			get { return status; }
			set { status = value; }
		}

		public SaleDto()
		{
			status = "unpaid";
		}//this constructor is here to remove warnings but neverthless i have more than 60 warnings here and there lol the memes were real... 
		
	}
}
