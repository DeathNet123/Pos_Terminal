using System.Globalization;
using System.Reflection;

namespace DTO
{
    public class ItemDto
    {
		private int id;

		public int Id
		{
			get { return id; }
			set { id = value; }
		}

		private String description;

		public String Description
		{
			get { return description; }
			set { description = value; }
		}

		private decimal price;

		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}

		private int quantity;

		public int Quantity
		{
			get { return quantity; }
			set { quantity = value; }
		}

		private DateTime creation_date;

		public DateTime CreationDate
		{
			get { return creation_date; }
			set { creation_date = value; }
		}

		public ItemDto()
		{
			description = String.Empty;
			CreationDate = DateTime.Now;
		}

        public override string ToString()
        {
			TextInfo ti = new CultureInfo("en-US").TextInfo;
			return $"ID : {Id}\nDescription : {ti.ToTitleCase(Description)}\nPrice : {Price:C}\nQuantity : {Quantity}\nCreationDate : {CreationDate.Date.ToString("yyyy/MM/dd")}\n";
        }

		public string Criteria()
		{
			String toPrint = "";
			
			if (Id != -1)
				toPrint += $" or ItemId = @i";
			if(Description != "")
                toPrint += $" or Description = @d";
			if (!CreationDate.ToString().Equals(new DateTime().ToString()))
				toPrint += $" or CreationDate = @c";
			if(Price != 0)
			{
                toPrint += $" or Price = @p";
            }
			if(Quantity!= -1) 
			{
				toPrint += $" or Quantity = @q";
			}
			
			return toPrint.Substring(4);
        }
	}
}