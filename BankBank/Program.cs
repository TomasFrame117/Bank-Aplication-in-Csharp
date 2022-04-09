// See https://aka.ms/new-console-template for more information

using BankBank;

namespace SuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BanckAccount("Scott", 10000);
            var account2 = new BanckAccount("Joakim", 30000);

            Console.WriteLine($"account {account.Number} was created for {account.Owner} with {account.Balance} kr on it");
            account.MakeDeposit(102, DateTime.Now, "Herligalondon");
            Console.WriteLine(account.Balance);
            account.MakeWithdrawal(4000, DateTime.Today, "Parrafinlæmpen");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(2000, DateTime.Now, $"donation{account2.Owner}");
            Console.WriteLine(account.Balance);

            Console.WriteLine(account.getaccaountHistory());


            Console.WriteLine($"Account {account2.Number} was created for {account2.Owner} with a balance of {account2.Balance} kr on it.");
            account2.MakeWithdrawal(2000, DateTime.Now, $"doation{account.Owner}");
            Console.WriteLine(account2.Balance);
            account2.MakeWithdrawal(account2.Balance, DateTime.Now, "cryptobama.com");
            Console.WriteLine(account2.Balance);


        }
    }
}