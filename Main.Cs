using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;


namespace Program
{
        class Program
    {
    
        static void Main(string [] args)
        {

            //Variables
            bool keepRunning = true;
            int userChoice = 0;

            List<Bank> accounts = new List<Bank>();

            while (keepRunning)
            {
                int numAccounts = accounts.Count;
                Console.WriteLine("Welcome to Ramsey Bank Inc.");
                PrintMenu();

                //Get user's choice of input
                bool validInput = false;
                while (!validInput)
                {
                    Console.Write("Enter your choice: ");
                    string input = Console.ReadLine();

                    if (int.TryParse(input, out userChoice) && userChoice >= 1 && userChoice <= 5)
                    {
                        validInput = true;
                    }
                    //String or something else is entered
                    else
                    {
                        Console.WriteLine("Error, invalid option. Please try again.");
                    }
                }
                
                //Cases for the user's choice

                switch (userChoice)
                {
                    //create an account
                    case(1):
                        Console.WriteLine("Create account option chosen.");
                        Console.WriteLine("Please enter only alphabetical characters a-z");

                        //check the string for special characters or numbers
                        string inputName;
                        while(true)
                        {
                            Console.Write("Enter the name of your account: ");
                            inputName = Console.ReadLine();

                            //check input is valid
                            if(!string.IsNullOrWhiteSpace(inputName) && Regex.IsMatch(inputName, @"^[a-zA-Z]+$"))
                            {
                                break;
                            }

                            Console.Clear();
                            Console.WriteLine("Invalid input. Numbers and special characters not allowed. \n");
                        }

                        Console.WriteLine($"Creating account with name: {inputName}");

                        Bank newBank = new Bank(inputName);
                        accounts.Add(newBank);

                        Console.WriteLine();
                        break;
                    
                    //Deposit Money Option
                    case(2):

                        if(numAccounts > 0)
                        {
                            Console.WriteLine("Deposit money option chosen.");

                            //input loop
                            int depositAmount;
                            while(true)
                            {
                                Console.WriteLine("Enter the amount of money you want to deposit.");
                                int.TryParse(Console.ReadLine(), out depositAmount);
                                if (depositAmount > 0)
                                {
                                    break;
                                }

                                else
                                {
                                    Console.WriteLine("Enter an amount > $0");
                                }
                            }


                            PrintAccounts(accounts);

                            int accountChoice;
                            while(true)
                            {
                                Console.WriteLine("Which account are you depositing the money into.");
                                int.TryParse(Console.ReadLine(), out accountChoice);

                                if (accountChoice < 1 || accountChoice > numAccounts)
                                {
                                    Console.WriteLine("Please enter a valid account number.");
                                }
                                else
                                {
                                    break;
                                }
                            }

                            accounts[accountChoice - 1].Deposit(depositAmount);

                        }
                        else
                        {
                            Console.WriteLine("Please create an account first.");
                        }
                        break;

                    //Withdraw money option
                    case(3):
                        if(numAccounts > 0)
                        {
                            Console.WriteLine("Withdraw money option chosen.");
                            //input loop
                            int withdrawAmount;
                            while(true)
                            {
                                Console.WriteLine("Enter the amount of money you want to withdraw.");
                                int.TryParse(Console.ReadLine(), out withdrawAmount);
                                if (withdrawAmount > 0)
                                {
                                    break;
                                }

                                else
                                {
                                    Console.WriteLine("Enter an amount > $0");
                                }
                            }

                            PrintAccounts(accounts);

                            int accountChoice;
                            while(true)
                            {
                                Console.WriteLine("Which account are you witdrawing the money from.");
                                int.TryParse(Console.ReadLine(), out accountChoice);

                                if (accountChoice < 1 || accountChoice > numAccounts)
                                {
                                    Console.WriteLine("Please enter a valid account number.");
                                }
                                else
                                {
                                    break;
                                }
                            }

                            accounts[accountChoice - 1].Withdraw(withdrawAmount);

                        }
                        break;

                    //Check Accounts Option
                    case(4):
                        if (numAccounts > 0)
                        {
                            Console.WriteLine("Check accounts option chosen.");
                            PrintAccounts(accounts);
                        }
                        break;
                    case(5):
                        Console.WriteLine("Quit program option chosen.");
                        keepRunning = false;
                        break;
                }

                Console.WriteLine();

            }
            
            Console.WriteLine("Thank you for choosing Ramsey Bank Inc. See you again soon!");

        }

        //print methods
        static void PrintMenu()
        {
            Console.WriteLine("What would you like to do today!");
            Console.WriteLine("1. Create a new account.");
            Console.WriteLine("2. Deposit money into an account");
            Console.WriteLine("3. Withdraw money from an account");
            Console.WriteLine("4. Check accounts");
            Console.WriteLine("5. Quit the program");
        }

        //Prints full account name and balance
        static void PrintAccounts(List<Bank> accounts)
        {
            int num = 1;
            foreach(Bank account in accounts)
            {
                Console.WriteLine($"Account #{num}: {account.Name}, Balance {account.Balance}");
                num += 1;
            }

            Console.WriteLine();
        }

        //print just the accounts and names
        static void PrintAccountNames(List<Bank> accounts)
        {
            int num = 1;
            foreach(Bank account in accounts)
            {
                Console.WriteLine($"Account #{num}: {account.Name}");
                num += 1;
            }

            Console.WriteLine();
        }
    }
}
