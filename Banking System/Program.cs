using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    class Transaction
    {
        public double amount;
        public DateTime date;
        public string transactionType;
        public Transaction(string transactionType, double amount, DateTime dateTime)
        {
            this.amount = amount;
            this.date = dateTime;
            this.transactionType = transactionType;
        }
    }
    class Account
    {
        public int account_Number;
        public string AccountHolderName;
        public double Balance;
        public List<Transaction> transactionsHistory;
        public Account(int acc_num,string name,double bal)
        {
            this.account_Number = acc_num;
            this.AccountHolderName = name;
            this.Balance = bal;
            transactionsHistory = new List<Transaction>();
        }
        public void Deposit(double amount)
        {
            Balance += amount;
            Transaction transaction = new Transaction("Deposit", amount, DateTime.Now);
            transactionsHistory.Add(transaction);
            if (transactionsHistory.Count > 0)
            {
                Console.WriteLine("Transaction Successfully done");
            }
            else
            {
                Console.WriteLine("Transaction not Done");
            }
            Console.WriteLine($"Total Balance : {Balance}");
        }
        public virtual void Withdraw(double amountToWithdraw)
        {
            if (Balance < amountToWithdraw)
            {
                Console.WriteLine($"Not Enough Amount Present in this Account");
            }
            else
            {
                Balance -= amountToWithdraw;
                Transaction transaction = new Transaction("withdraw", amountToWithdraw, DateTime.Now);
                transactionsHistory.Add(transaction);
                Console.WriteLine($"Transaction successfully! Remaining Balance : {Balance}");
            }
        }
        public virtual string GetDetails()
        {
            return $"Account_Number {account_Number} Name {AccountHolderName} Balance {Balance}";
        }
    }
    class SavingAccount : Account
    {
        public int interest_level;
        public int endYear;
        public SavingAccount(int account_Number,string AccountHolderName,double Balance,int interest_level,int endYear) : base(account_Number, AccountHolderName, Balance)
        {
            this.interest_level = interest_level;
            this.endYear = endYear;
        }
        public void interest_Calculation()
        {
            double interest = Balance * interest_level;
            Balance += interest;
            Console.WriteLine($"Interest of {interest} added. New Balance {Balance}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Enter the Account Number");
            int accountNumber =Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the Balance");
            double balance = Convert.ToDouble(Console.ReadLine());
            Account a = new Account(accountNumber, name, balance);
            a.GetDetails();
            Console.WriteLine("Enter the Amount to Deposit");
            double amountToDeposit = Convert.ToDouble(Console.ReadLine());
            a.Deposit(amountToDeposit);
            Console.WriteLine("Enter the Amount to Withdraw");
            double amountToWithdraw = Convert.ToDouble(Console.ReadLine());
            a.Withdraw(amountToWithdraw);
            SavingAccount account = new SavingAccount(123, "Mubashir Liaqat", 2350, 34, 2003);
            account.GetDetails();
            account.interest_Calculation();
            Console.ReadKey();
        }
    }
}
