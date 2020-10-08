using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
    public interface VMInterface
    {
        private static int[] denominations = null;
        private static int usrMoney = 0;
        private static int usrQty = 0;
        private static List<Product> allProducts = new List<Product>();

        public void DisplayMessage(String message);
        public void AddProducts(Product p);
        public void DisplayProducts(bool userInputOption);
        public int ShowBalance();
        public bool BuyProduct(bool userInputOption, int pickedProductNumber);
        public int[] DispenseBalAmt(bool userInputOption);
        public void MoneyPoolScreen(bool userInputOption);
    }
}
