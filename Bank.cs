using System;
using System.Threading.Tasks.Dataflow;

namespace Program
{
        class Bank
    {
        private string name;
        private decimal balance;

        //Constructors
        public Bank(string name, decimal balance)
        {
            this.name = name;
            this.balance = balance;
        }

        public Bank(string name)
        {
            this.name = name;
            balance = 0;
        }

        public Bank()
        {
            name = "Default";
            balance = 0;
        }

        //Getters & Setters
        public decimal Balance
        {
            get {return balance;}
            private  set {balance = value;}
        }

        public string Name
        {
            get {return name;}
            set {name = value;}
        }

        //Method to deposit money into account
        public void Deposit(decimal value)
        {
            //As long as money deposited is postive
            if (value > 0)
            {
                Console.WriteLine($"Depositing ${value:F2} to {name}");

                decimal oldBalance = balance;

                balance += value;

                Console.WriteLine("Success!");
                Console.WriteLine($"Old Balance: ${oldBalance:F2}, New Balance: ${balance:F2}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Error, Value has to be greater than $0.00");
            }
        }

        //Method to witdraw money from an account
        public void Withdraw (decimal value)
        {
            //As long as money deposited is postive
            if (value > 0 && balance >= value)
            {
                Console.WriteLine($"Withdrawing ${value:F2} from {name}");

                decimal oldBalance = balance;

                balance -= value;

                Console.WriteLine("Success!");
                Console.WriteLine($"Old Balance: ${oldBalance:F2}, New Balance: ${balance:F2}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine($"Error, Value has to be greater than $0.00 or not enough money in account.");
            }
        }

    }
}
