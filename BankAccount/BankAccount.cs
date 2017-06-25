using System;
namespace BankAccount
{
	public class BankAccount
	{

		public double MoneyInAccount{
			get; private set;
		}

		public BankAccount(double startingAmount = 100){
			MoneyInAccount = startingAmount;
		}

		public bool Withdraw(double amount){
			if (amount > MoneyInAccount)
				return false;
			else
			{
				MoneyInAccount -= amount;
				return true;
			}
		}


		public void Deposit(double amount){
			MoneyInAccount += amount;
		}


		
	}
}







