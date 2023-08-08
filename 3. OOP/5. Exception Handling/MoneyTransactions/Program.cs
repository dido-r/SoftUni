using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(new char[] { '-', ',' });
            List<BankAccount> listOfAccounts = new List<BankAccount>();

            for (int i = 0; i < data.Length; i += 2)
            {
                BankAccount bankAccount = new BankAccount(int.Parse(data[i]), double.Parse(data[i + 1]));
                listOfAccounts.Add(bankAccount);
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    var curretAccount = listOfAccounts.First(x => x.BankNumber == int.Parse(command[1]));

                    switch (command[0])
                    {
                        case "Deposit":
                            curretAccount.BankBalance += double.Parse(command[2]);
                            break;
                        case "Withdraw":
                            if (curretAccount.BankBalance < double.Parse(command[2]))
                            {
                                throw new ArithmeticException("Insufficient balance!");
                            }
                            curretAccount.BankBalance -= double.Parse(command[2]);
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {curretAccount.BankNumber} has new balance: {curretAccount.BankBalance:f2}");
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (ArithmeticException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message); ;
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                    input = Console.ReadLine();
                }
            }
        }
    }

    class BankAccount
    {
        public BankAccount(int number, double balance)
        {
            BankNumber = number;
            BankBalance = balance;
        }
        public int BankNumber { get; private set; }
        public double BankBalance { get; set; }
    }
}
