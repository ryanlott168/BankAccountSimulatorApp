using Xamarin.Forms;
using System;

namespace BankAccount
{
	public partial class BankAccountPage : ContentPage
	{


		private BankAccount wallet;
		private BankAccount bankAccount;

		private Entry amountEntry;
		Label walletLabel;
		Label bankAccountLabel;


		public BankAccountPage()
		{


			wallet = new BankAccount();
			bankAccount = new BankAccount();


			Button depositButton = new Button { Text = "Deposit To Bank" };
			Button withdrawButton = new Button { Text = "Withdraw From Bank" };

			amountEntry = new Entry { Text = "Enter Amount of Money" };
			walletLabel = new Label();
			bankAccountLabel = new Label();

			amountEntry.Keyboard = Keyboard.Numeric;
			depositButton.Clicked += DepositButton_Clicked;
			withdrawButton.Clicked += WithdrawButton_Clicked;


			Content = new StackLayout
            {
                Padding = 20,
                Children = {
                    amountEntry,
                    depositButton,
                    withdrawButton,
                    new Label {Text ="My Wallet",FontAttributes=FontAttributes.Bold,FontSize=18 },
                    walletLabel,
                    new Label {Text ="Bank Account",FontAttributes=FontAttributes.Bold,FontSize=18 },
                    bankAccountLabel
                }
            };
            UpdateLabels();
		}


		public void DepositButton_Clicked(object sender, EventArgs e){
			TransferMoney(wallet, bankAccount);
		}

		public void WithdrawButton_Clicked(object sender, EventArgs e){
			TransferMoney(bankAccount, wallet);
		}

		public void TransferMoney(BankAccount sendingAccount, BankAccount receivingAccount){

			double sendingAmount;

			if (double.TryParse(amountEntry.Text, out sendingAmount)){

				if (sendingAccount.Withdraw(sendingAmount)){
					receivingAccount.Deposit(sendingAmount);
					UpdateLabels();
				}
				else
					DisplayAlert("Out of money", "Cannot transfer amount.", "Okay");
			}
			else{
				DisplayAlert("Invalid Entry", "Please try again with valid entry.", "Okay");
			}
		}

		private void UpdateLabels() {
			walletLabel.Text = wallet.MoneyInAccount.ToString("C");
			bankAccountLabel.Text = bankAccount.MoneyInAccount.ToString("C");
				}


	}
}
