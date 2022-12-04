using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDto
    {
		private int? CustomerId;

		public int? GetCustomerId
		{
			get { return CustomerId; }
			set { CustomerId = value; }
		}

		private String? Name;

		public String? GetName 
		{
			get { return Name; }
			set { Name = value; }
		}

		private String? Address;

		public String? GetAddress
		{
			get { return Address; }
			set { Address = value; }
		}

		private decimal? AmountPayable;

		public decimal? GetAmount
		{
			get { return AmountPayable; }
			set { AmountPayable = value; }
		}

		private String? Email;

		public String? GetEmail
		{
			get { return Email; }
			set { Email = value; }
		}

		private String? Phone;

		public String? GetPhone
		{
			get { return Phone; }
			set { Phone = value; }
		}

		private decimal? SalesLimit;

		public decimal? GetSalesLimit
		{
			get { return SalesLimit; }
			set { SalesLimit = value; }
		}

		public CustomerDto()
		{
			Name = "";
			Email = "";
			Address = "";
			Phone = "";
			GetAmount = 0;
		}

        public override string ToString()
        {
            TextInfo ti = new CultureInfo("en-US").TextInfo;
			return $"ID : {GetCustomerId}\nName : {ti.ToTitleCase(GetName)}\nAddress : {GetAddress}\nPhone : {GetPhone}\nEmail : {GetEmail}\nAmountPayable : {GetAmount:C}\nSalesLimit : {GetSalesLimit:C}";
        }

		public String Criteria()
		{
			String criteria = "";
			foreach(PropertyInfo prop in this.GetType().GetRuntimeProperties())
			{
				if(prop.GetValue(this, null) != null)
					criteria += $" or {prop.Name.Substring(3)} = @{prop.Name.ToLower().Substring(3, 2)}";
			}
			return criteria.Substring(4);
		}
    }
}
