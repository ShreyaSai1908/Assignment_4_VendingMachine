using System;

namespace Assignment_4_VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
			bool runMachine = true;
			int usrChoice = 0;

			VendingMachine myVendingMachine = new VendingMachine();

			while (runMachine)
			{
				Console.WriteLine("**********************************************************");
				Console.WriteLine("*****************Shreya's Vending Machine*****************");
				Console.WriteLine("**********************************************************");

				Console.WriteLine("(1) Add Money");
				Console.WriteLine("(2) Buy");
				Console.WriteLine("(3) Exit");
				Console.Write("Your Choice (1-3):");
				usrChoice = Convert.ToInt32(Console.ReadLine());

				switch (usrChoice)
				{
					case 1:
						myVendingMachine.MoneyPoolScreen(true);
						break;

					case 2:
						myVendingMachine.BuyProduct(true, -1);
						break;

					case 3:
						myVendingMachine.DispenseBalAmt(true);
						runMachine = false;
						break;
				}
			}

		}
	}
}
