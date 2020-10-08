using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
    public class PizzaSlice : Product
    {
        public PizzaSlice()
        {
            this.ProductID = 3;
            this.ProductName = "Pizza Slice";
            this.ProductDesc = "Pack of 2*200 grams vegeterian pizza slice with tommatoes, x-tra cheese, olives & mushrooms";
            this.ProductPrice = 36;
            this.ProductUsage = "Lift the front cover up of the boz. It's only deliciousness inside!";
        }
    }
}
