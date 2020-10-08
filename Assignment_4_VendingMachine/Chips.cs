using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
	public class Chips : Product
	{
		public Chips()
		{
			this.ProductID = 2;
			this.ProductName = "Potato Chips";
			this.ProductDesc = "200 grams of salted potato chips.";
			this.ProductPrice = 18;
			this.ProductUsage = "Zip off the packet from the top. Enjoy the crunchiness!";
		}

	}
}
