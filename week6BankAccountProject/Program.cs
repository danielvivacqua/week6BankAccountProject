using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week6BankAccountProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Account userAccount = new Account();
            userAccount.AccountNumber = Account.RandAccountNum();
            //Console.WriteLine(userAccount.AccountNumber);
            Client userClient = new Client();
            string fileName = "AccountSummary.txt";
            StreamWriter writer = new StreamWriter(fileName);
            using (writer)
            {
                writer.WriteLine("*****Account Summary*****");
                writer.WriteLine(userClient.Name);
                writer.WriteLine("Account Number: " + userAccount.AccountNumber);
                writer.WriteLine(" ");
                string userAgain = "";
                do
                {
                    Console.WriteLine("************************");
                    Console.WriteLine("Bank Account Option Menu");
                    Console.WriteLine("************************\n");
                    Console.WriteLine("1. View Client Information \n2. View Account Balance \n3. Deposit Funds \n4. Withdraw Funds \n5. Exit");

                    int userInput = int.Parse(Console.ReadLine());

                    switch (userInput)
                    {
                        case 1:
                            userClient.ClientInfo();
                            userAccount.AccountInfo();
                            Console.WriteLine("Would you like to make another transaction? Y/N");
                            userAgain = Console.ReadLine().ToUpper();
                            break;
                        case 2:
                            Console.WriteLine(userAccount.AccountBalance);
                            Console.WriteLine("Would you like to make another transaction? Y/N");
                            userAgain = Console.ReadLine().ToUpper();
                            break;
                        case 3:
                            userAccount.Deposit();
                            writer.WriteLine(DateTime.Now + " " + " +$" + userAccount.DepositAmount + " $" + userAccount.AccountBalance);
                            Console.WriteLine("Would you like to make another transaction? Y/N");
                            userAgain = Console.ReadLine().ToUpper();
                            break;
                        case 4:
                            userAccount.Withdraw();
                            writer.WriteLine(DateTime.Now + " " + " -$" + userAccount.WithdrawAmount + " $" + userAccount.AccountBalance);
                            Console.WriteLine("Would you like to make another transaction? Y/N");
                            userAgain = Console.ReadLine().ToUpper();
                            break;
                        case 5:
                            Console.WriteLine("Goodbye.");
                            userAgain = "N";
                            break;
                        default:
                            Console.WriteLine("Not a valid entry.");
                            Console.WriteLine("Would you like to make another transaction? Y/N");
                            userAgain = Console.ReadLine().ToUpper();
                            break;
                    }
                } while (userAgain == "Y");
            }
        }
    }
      
    class Client
    {
        //fields
        private string name = "Daniel Vivacqua";
        private string ageGroup = "Adult";

        //properties
        public virtual string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public virtual string AgeGroup
        {
            get { return this.ageGroup; }
            set { this.ageGroup = value; }
        }

        //methods
        public void ClientInfo()
        {
            Console.WriteLine(this.Name);
        }

        //constructor
        public Client()
        {

        }      
                
    }
    class Account
    {
        //fields
        private decimal accountBalance = 0.00M;
        private int accountNumber;

        //properties
        public decimal AccountBalance
        {
            get { return this.accountBalance; }
            set { this.accountBalance = value; }
        }

        public int AccountNumber
        {
            get { return this.accountNumber; }
            set { this.accountNumber = value; }
        }

        public decimal DepositAmount { get; set; }
        public decimal WithdrawAmount { get; set; }

        //methods
        public void Deposit()
        {
            Console.WriteLine("Please enter an amount you wish to deposit.");
            DepositAmount = decimal.Parse(Console.ReadLine());
            AccountBalance += DepositAmount;
        }

        public void Withdraw()
        {
            Console.WriteLine("Please enter an amount you wish to withdraw.");
            WithdrawAmount = decimal.Parse(Console.ReadLine());
            AccountBalance -= WithdrawAmount;
        }

        public void AccountInfo()
        {
            Console.WriteLine("Account number: " + this.AccountNumber);
            Console.WriteLine("Current balance: $" + this.AccountBalance);
        }

        static public int RandAccountNum()
        {
            Random random = new Random();
            int minValue = 1000;
            int maxValue = 9999;
            int randomNum = random.Next(minValue, maxValue);
            return randomNum;
        }

        //constructors
        public Account()
        {

        }
    }
}

