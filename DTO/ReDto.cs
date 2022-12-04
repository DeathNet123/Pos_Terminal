using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReDto
    {
		private int recieptno;

		public int RecieptNo
		{
			get { return recieptno; }
			set { recieptno = value; }
		}

		private int orderid;

		public int OrderId
		{
			get { return orderid; }
			set { orderid = value; }
		}

		private DateTime date;

		public DateTime RecieptDate
		{
			get { return date; }
			set { date = value; }
		}

		private decimal amount;

		public decimal Amount
		{
			get { return amount; }
			set { amount = value; }
		}



	}
}
