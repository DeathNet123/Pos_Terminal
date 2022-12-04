using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LineItemDto
    {
		private int lineid;

		public int LineId
		{
			get { return lineid; }
			set { lineid = value; }
		}

		private int orderid;

		public int OrderId
		{
			get { return orderid; }
			set { orderid = value; }
		}

		private int itemid;

		public int ItemId
		{
			get { return itemid; }
			set { itemid = value; }
		}

		private int quantity;

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		private decimal amount;

		public decimal Amount
		{
			get { return amount; }
			set { amount = value; }
		}

	}
}
