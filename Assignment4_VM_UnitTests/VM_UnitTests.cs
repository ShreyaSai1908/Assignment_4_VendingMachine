using System;
using Xunit;
using System.Collections.Generic;
using Assignment_4_VendingMachine;

namespace Assignment4_VM_UnitTests
{
    public class VM_UnitTests
    {
        [Fact]
        public void AddProductsTest_1()
        {
            //Arrange
            VendingMachine VendingMachine = null; ;

            //Act
            VendingMachine = new VendingMachine(1); //added product 1 - Coke
            List<Product> allProducts = VendingMachine.AllProducts;

            //Assert //to check if there is one product only
            Assert.Single(allProducts);

        }

        [Fact]
        public void AddProductsTest_2()
        {
            //Arrange
            VendingMachine VendingMachine = null;

            //Act
            VendingMachine = new VendingMachine(1); //added product 1 - Coke
            List<Product> allProducts = VendingMachine.AllProducts;

            //Assert //to check if the product is Coke or not
            foreach (Product p in allProducts)
            {
                Assert.NotNull(p);
                Assert.Contains("Coke", p.Examine());
            }

        }

        [Fact]
        public void AddProductsTest_3()
        {
            //Arrange
            VendingMachine VendingMachine = null;

            //Act
            VendingMachine = new VendingMachine(1); //added product 1 - Coke
            List<Product> allProducts = VendingMachine.AllProducts;

            //Assert //to check if the product is Coke or not
            foreach (Product p in allProducts)
            {
                Assert.NotNull(p);
                Assert.Contains("Chips", p.Examine());
            }
        }

        [Fact]
        public void BuyProductTest_1()
        {
            //Arrange
            int balanceAmt = 0;
            VendingMachine VendingMachine = null;

            //Act
            VendingMachine = new VendingMachine(1);     //added product 1 - Coke // Price = 27
            List<Product> allProducts = VendingMachine.AllProducts; //get all the products 
            VendingMachine.UsrQty = 1;
            bool purchaseSuccess = VendingMachine.BuyProduct(false, 1);


            //Assert //Money Pool = 0
            Assert.False(purchaseSuccess);
            Assert.Equal(balanceAmt, VendingMachine.ShowBalance());
        }

        [Fact]
        public void BuyProductTest_2()
        {
            //Arrange
            int balanceAmt = 0;
            VendingMachine VendingMachine = null;

            //Act
            VendingMachine = new VendingMachine(1);     //added product 1 - Coke // Price = 27
            List<Product> allProducts = VendingMachine.AllProducts; //get all the products 
            VendingMachine.UsrQty = 1;
            VendingMachine.AddMoney(4);
            bool purchaseSuccess = VendingMachine.BuyProduct(false, 1);

            //Assert //Money Pool = 50
            Assert.True(purchaseSuccess);
            balanceAmt = 50 - 27;
            Assert.Equal(balanceAmt, VendingMachine.ShowBalance());
        }



        [Fact]
        public void DispenseBalAmtTest_1()
        {
            //Arrange
            int balanceAmt = 0;
            int[] coinArray;
            int noOfDenominations = 8;
            VendingMachine VendingMachine = null;

            //Act
            VendingMachine = new VendingMachine(1);     //added product 1 - Coke // Price = 27
            List<Product> allProducts = VendingMachine.AllProducts; //get all the products 
            VendingMachine.UsrQty = 1;
            VendingMachine.AddMoney(3); //adding 20 to wallet
            VendingMachine.AddMoney(2); //adding 10 to wallet
            bool purchaseSuccess = VendingMachine.BuyProduct(false, 1);
            coinArray = VendingMachine.DispenseBalAmt(false);
            balanceAmt = 30 - 27;

            //Assert //Money Pool = 30
            Assert.NotNull(coinArray);
            Assert.True(purchaseSuccess);
            Assert.Equal(noOfDenominations, coinArray.Length);
            Assert.Equal(balanceAmt, VendingMachine.ShowBalance());
            Assert.Equal(balanceAmt, coinArray[0]);

        }

        [Fact]
        public void DispenseBalAmtTest_2()
        {
            //Arrange
            int balanceAmt = 0;
            int[] coinArray;
            int noOfDenominations = 8;
            VendingMachine VendingMachine = null;

            //Act
            VendingMachine = new VendingMachine(1);     //added product 1 - Coke // Price = 27
            List<Product> allProducts = VendingMachine.AllProducts; //get all the products 
            VendingMachine.UsrQty = 1;
            VendingMachine.AddMoney(3); //adding 20 to wallet
            VendingMachine.AddMoney(2); //adding 10 to wallet
            bool purchaseSuccess = VendingMachine.BuyProduct(false, 1);
            coinArray = VendingMachine.DispenseBalAmt(false);
            balanceAmt = 30 - 27;  //Money Pool = 30

            //Assert 
            Assert.NotNull(coinArray);
            Assert.True(purchaseSuccess);
            Assert.Equal(noOfDenominations, coinArray.Length);
            Assert.Equal(balanceAmt, VendingMachine.ShowBalance());
            Assert.Equal(balanceAmt, coinArray[0]);
            Assert.Equal(balanceAmt, coinArray[1]);
            Assert.Equal(balanceAmt, coinArray[2]);
            Assert.Equal(balanceAmt, coinArray[3]);
            Assert.Equal(balanceAmt, coinArray[4]);
            Assert.Equal(balanceAmt, coinArray[5]);
            Assert.Equal(balanceAmt, coinArray[6]);
            Assert.Equal(balanceAmt, coinArray[7]);

        }
    }
}
