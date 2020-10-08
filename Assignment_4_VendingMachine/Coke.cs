using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
    public class Coke : Product
    {
        public Coke()
        {
            this.ProductID = 1;
            this.ProductName = "Coke";
            this.ProductDesc = "250 ml pet carbonated bottle. Includes added Sugar";
            this.ProductPrice = 27;
            this.ProductUsage = "Click open the can. Relax and enjoy the drink!";
        }
    }
}
