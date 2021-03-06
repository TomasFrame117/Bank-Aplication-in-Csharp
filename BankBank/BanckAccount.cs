using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankBank
{
    internal class BanckAccount
    {
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get {
                decimal balance = 0;
                foreach (var item in allTransactions) {
                    balance += item.Amount;
                }
                return balance;
            } 
        }

        private static int kontoNumber = 1234567890;

        private List<Transaction> allTransactions = new List<Transaction>();
        public BanckAccount(string name, decimal tall)
        {
            this.Owner = name;

            MakeDeposit(tall, DateTime.Now, "tall");

            this.Number = kontoNumber.ToString();
            kontoNumber++;
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if(amount <= 0) 
            {
                throw new ArgumentOutOfRangeException (nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction (amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "amount of withdrawal must be positive");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("not sufficient funds for this withdrawl");
            }
            var withdrawal = new Transaction (-amount, date, note);
            allTransactions.Add (withdrawal);
        }

        public string getaccaountHistory()
        {
            var report = new StringBuilder();

            report.AppendLine("Date\t\tAmount\t\tNote");
            foreach (var item in allTransactions)
            {
                report.AppendLine($"{item.Date}\t\t{item.Amount}\t\t{item.Notes}");
            }
            return report.ToString();
        }
    }
}
