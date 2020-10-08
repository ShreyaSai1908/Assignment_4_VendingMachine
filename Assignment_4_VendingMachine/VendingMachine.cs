using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_4_VendingMachine
{
    public class VendingMachine : VMInterface
    {
		private static int[] denominations = { 1, 5, 10, 20, 50, 100, 500, 1000 };

		private static int usrMoney;
		public static int UsrMoney { get { return usrMoney; } set { usrMoney = value; } }

		private static int usrQty;
		public static int UsrQty { get { return usrQty; } set { usrQty = value; } }

		private static List<Product> allProducts = new List<Product>();
		public static List<Product> AllProducts { get { return allProducts; } set { allProducts = value; } }

		public VendingMachine()
		{
			DefineProducts(1);
			DefineProducts(2);
			DefineProducts(3);
			UsrMoney = 0;
			UsrQty = 0;
		}

		public VendingMachine(int productNumber)
		{
			DefineProducts(productNumber);
			UsrMoney = 0;
			UsrQty = 0;
		}

		public void DefineProducts(int productNumber)
		{
			Product p = null;

			switch (productNumber)
			{
				case 1:
					p = new Coke();
					break;
				case 2:
					p = new Chips();
					break;
				case 3:
					p = new PizzaSlice();
					break;
			}
			AddProducts(p);
		}

		public void AddProducts(Product p)
		{
			allProducts.Add(p);
		}

		public void DisplayProducts(bool userInputOption)
		{
			if (userInputOption)
			{
				Clear(userInputOption);
				ShowBalance();
				foreach (Product p in allProducts)
				{
					Console.WriteLine();
					Console.WriteLine("******************************************************************");
					Console.WriteLine("(" + p.ProductID + "):");
					Console.WriteLine("-------------------------------------------------");
					Console.WriteLine(p.Examine());
					Console.WriteLine("******************************************************************");
					Console.WriteLine();
				}
			}
		}

		public int getBoughtProduct(bool userInputOption, int pickedProductNumber)
		{
			int consoleInput;
			int selectedProductNumber;
			if (userInputOption)
			{
				DisplayProducts(userInputOption);
				Console.Write("Your Choice (1-3):");
				consoleInput = Convert.ToInt32(Console.ReadLine());
				selectedProductNumber = consoleInput;

				Console.WriteLine();
				Console.Write("Quantity:");
				UsrQty = Convert.ToInt32(Console.ReadLine());

			}
			else
			{
				selectedProductNumber = pickedProductNumber;
			}

			return selectedProductNumber;
		}

		public void MoneyPoolScreen(bool userInputOption)
		{
			if (userInputOption)
			{
				int usrInput = 0;
				Clear(userInputOption);
				Console.WriteLine("Press the corresponding number to add money:");
				for (int i = 0; i < denominations.Length; i++)
				{
					Console.WriteLine("(" + (i + 1) + ")" + denominations[i] + "    SEK");
				}
				Console.Write("Your Choice (1-8):");
				usrInput = Convert.ToInt32(Console.ReadLine());
				AddMoney(usrInput - 1);
				Clear(userInputOption);
				DisplayMessage("SEK " + denominations[usrInput - 1] + " added to your wallet!");
				ShowBalance();
				Hold(userInputOption);
				Clear(userInputOption);
			}
		}

		public void AddMoney(int moneyOption)
		{
			UsrMoney = UsrMoney + denominations[moneyOption];
		}

		public bool BuyProduct(bool userInputOption, int pickedProductNumber)
		{
			bool purchaseApproved = false;
			int boughtProductID = getBoughtProduct(userInputOption, pickedProductNumber);
			Product boughtProduct = getProductByID(boughtProductID);
			purchaseApproved = boughtProduct.Purchase(boughtProduct, UsrQty, UsrMoney);
			if (purchaseApproved)
			{
				UsrMoney = UsrMoney - (boughtProduct.ProductPrice * UsrQty);
				DisplayMessage("You Bought:" + boughtProduct.ProductName + "-" + boughtProduct.ProductDesc);
				ShowBalance();
				Hold(userInputOption);
				Clear(userInputOption);
			}
			else
			{
				Clear(userInputOption);
				DisplayMessage("Ohhh No!!!. Insufficient money in the wallet. Please add some!");
				ShowBalance();
				Hold(userInputOption);
				Clear(userInputOption);
				MoneyPoolScreen(userInputOption);
			}

			return purchaseApproved;
		}

		/*
		public void approvePurchase(int boughtProductID)
		{
			Product boughtProduct = getProductByID(boughtProductID);
			if (usrMoney < (boughtProduct.ProductPrice * usrQty))
			{
				Clear();
				DisplayMessage("Ohhh No!!!. Insufficient money in the wallet. Please add some!");				
				ShowBalance();
				Hold();
				Clear();
				DisplayAndAddMoney();
			}
			else
			{
				usrMoney = usrMoney - (boughtProduct.ProductPrice * usrQty);
				DisplayMessage("You Bought:"+ boughtProduct.ProductName+ "-" + boughtProduct.ProductDesc);
				ShowBalance();
				Hold();
				Clear();				
			}
		}
		*/

		public Product getProductByID(int productID)
		{
			Product matchingProduct = null;
			foreach (Product p in allProducts)
			{
				if (p.ProductID == productID)
				{
					matchingProduct = p;
				}
			}

			return matchingProduct;
		}
		public int[] DispenseBalAmt(bool userInputOption)
		{
			int change = 0;
			int[] array1 = denominations;
			int[] array2 = new int[8];

			Clear(userInputOption);
			ShowBalance();


			change = usrMoney;
			DisplayMessage("**********************************");
			DisplayMessage("Dispensing Amount: " + change);
			DisplayMessage("**********************************");

			for (int i = array1.Length - 1; i >= 0; i--)
			{
				array2[i] = (change / array1[i]);
				change = change - (array1[i] * array2[i]);
				DisplayMessage("Number of " + array1[i] + "(s) =" + array2[i]);
			}
			return array2;
		}

		public int ShowBalance()
		{
			DisplayMessage("Available Balance:" + UsrMoney);
			return UsrMoney;
		}

		public void DisplayMessage(String message)
		{
			Console.WriteLine(message);
		}

		public void Clear(bool userInputOption)
		{
			if (userInputOption)
			{
				Console.Clear();
			}
		}

		public void Hold(bool userInputOption)
		{
			DisplayMessage("Press any key to cont...");
			if (userInputOption)
			{
				Console.ReadKey();
			}
		}

	}
}
