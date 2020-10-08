using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
    public abstract class Product
    {
        //private fields
        private int productID;
        private string productName;
        private string productDesc;
        private int productPrice;
        private string productUsage;

        //public property ProductName
        public int ProductID
        {
            get
            {
                return productID;
            }
            set
            {
                productID = value;
            }
        }

        //public property ProductName
        public string ProductName
        {
            get
            {
                return productName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product name cannot be null, empty, or only of white-space");
                }
                else
                {
                    this.productName = value;
                }

            }
        }

        //public property ProductDesc
        public string ProductDesc
        {
            get
            {
                return productDesc;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product Description cannot be null, empty, or only of white-space");
                }
                else
                {
                    this.productDesc = value;
                }

            }
        }

        //public property ProductPrice
        public int ProductPrice
        {
            get
            {
                return productPrice;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Product Price cannot be less than or equal to 0");
                }
                else
                {
                    this.productPrice = value;
                }

            }
        }

        //public property ProductUsage
        public string ProductUsage
        {
            get
            {
                return productUsage;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Product Usage cannot be null, empty, or only of white-space");
                }
                else
                {
                    this.productUsage = value;
                }

            }
        }

        public bool Purchase(Product purchasedProduct, int qty, int usrMoney)
        {
            bool approval = false;

            int reqAmt = purchasedProduct.ProductPrice * qty;

            if (usrMoney >= reqAmt)
            {
                approval = true;

            }

            return approval;
        }

        public string Examine()
        {
            return $"Name:{this.ProductName} \nDescription: {this.ProductDesc} \nPrice (SEK): {this.ProductPrice}";
        }

        public string Use()
        {
            return $"Usage:{this.ProductUsage}\n";
        }

    }

}
