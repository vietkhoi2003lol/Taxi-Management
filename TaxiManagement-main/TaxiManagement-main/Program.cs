using System;
using TaxiManagementAssignment;
using System.Collections.Generic;

namespace TaxiManagementAssignment
{
    class Program
    {
        //Everything static can be used directly. No need to refer to it by creating an object
       
        static void Main(string[] args)
        {//I don't know why I can not define this variables outside the Main method, Ask Fraser
            RankManager rankMgr = new RankManager();
            TaxiManager taxiMgr = new TaxiManager();
            TransactionManager transactionMgr = new TransactionManager();
            UserUI ui = new UserUI(rankMgr, taxiMgr, transactionMgr);
            int choose = 0;
            string logo = @"
████████  █████  ██   ██ ██     ███    ███  █████  ███    ██  █████   ██████  ███████ ██████  
   ██    ██   ██  ██ ██  ██     ████  ████ ██   ██ ████   ██ ██   ██ ██       ██      ██   ██ 
   ██    ███████   ███   ██     ██ ████ ██ ███████ ██ ██  ██ ███████ ██   ███ █████   ██████  
   ██    ██   ██  ██ ██  ██     ██  ██  ██ ██   ██ ██  ██ ██ ██   ██ ██    ██ ██      ██   ██ 
   ██    ██   ██ ██   ██ ██     ██      ██ ██   ██ ██   ████ ██   ██  ██████  ███████ ██   ██ 

";

            Console.WriteLine(logo);
            Console.WriteLine("Welcome Back!\n");
            DisplayMenu();
            choose = ReadInteger(Console.ReadLine());
            do
            {
                if (choose == 1)
                {
                    Console.Write("Enter taxi number you watn to add in rank: ");
                    int taxiNum = ReadInteger(Console.ReadLine());
                    Console.Write("Enter rank ID you want taxi to join: ");
                    int rankId = ReadInteger(Console.ReadLine());
                    foreach (string val in ui.TaxiJoinsRank(taxiNum, rankId))
                    {
                        Console.WriteLine(val);
                    }
                    DisplayMenu();
                    choose = ReadInteger(Console.ReadLine());
                }
                else if (choose == 2)
                {
                    Console.Write("Enter rank ID you want taxi to leave: ");
                    int rankId = ReadInteger(Console.ReadLine());
                    Console.Write("Enter destination: ");
                    string destination = Console.ReadLine();
                    Console.Write("Enter agreed price: ");
                    double agreedPrice = ReadDouble(Console.ReadLine());
                    foreach (string val in ui.TaxiLeavesRank(rankId, destination, agreedPrice))
                    {
                        Console.WriteLine(val);
                    }
                    DisplayMenu();
                    choose = ReadInteger(Console.ReadLine());
                }
                else if (choose == 3)
                {
                    Console.Write("Enter taxi number you want to drop fare: ");
                    int taxiNum = ReadInteger(Console.ReadLine());
                    Console.Write("Has passenger paid this taxi? [true/false]: ");
                    bool pricePaid = ReadBool(Console.ReadLine());
                    foreach (string val in ui.TaxiDropsFare(taxiNum, pricePaid))
                    {
                        Console.WriteLine(val);
                    }
                    DisplayMenu();
                    choose = ReadInteger(Console.ReadLine());
                }
                else if (choose == 4)
                {
                    foreach (string val in ui.ViewFinancialReport())
                    {
                        Console.WriteLine(val);
                    }
                    DisplayMenu();
                    choose = ReadInteger(Console.ReadLine());
                }
                else if (choose == 5)
                {
                    foreach (string val in ui.ViewTaxiLocations())
                    {
                        Console.WriteLine(val);
                    }
                    DisplayMenu();
                    choose = ReadInteger(Console.ReadLine());
                }
                else if (choose == 6)
                {
                    foreach (string val in ui.ViewTransactionLog())
                    {
                        Console.WriteLine(val);
                    }
                    DisplayMenu();
                    choose = ReadInteger(Console.ReadLine());
                }
                else if (choose == 7)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number from 1 - 7");
                    DisplayMenu();
                    choose = ReadInteger(Console.ReadLine());
                }
            } while (true);
           
            Console.WriteLine("Press Enter to close console");
            Console.ReadLine();
          
        }
        static private void DisplayMenu()
        {
            Console.WriteLine("\nEnter a number from 1 - 7");
            Console.WriteLine("[1] Taxi joins rank.");
            Console.WriteLine("[2] Taxi takes fare.");
            Console.WriteLine("[3] Taxi drops fare.");
            Console.WriteLine("[4] View financial report.");
            Console.WriteLine("[5] View taxi locations.");
            Console.WriteLine("[6] View transaction log.");
            Console.WriteLine("[7] Exit.\n");
        }
        static private double ReadDouble(string promt)
        {
            double money = 0;
            try
            {
                money = Convert.ToDouble(promt);
            }
            catch (Exception)
            {
                Console.WriteLine("\nInvalid input");
                Console.WriteLine("=====================================");
            }
            return money;
        }
        static private int ReadInteger(string promt)
        {
            int input = 0;
            try
            {
                input = Convert.ToInt32(promt);
            }
            catch (Exception)
            {
                Console.WriteLine("\nInvalid input");
                Console.WriteLine("=====================================");
            }
            return input;
        }
        static private bool ReadBool(string promt)
        {
            //Try to convert string to bool
            string input = promt;
            bool output;
            do
            {
                if (input == "true")
                {
                    output = true;
                    return output;
                }
                else if (input == "false")
                {
                    output = false;
                    return false;
                } else
                {
                    Console.WriteLine("Invalid input");
                    input = Console.ReadLine();
                }
            } while (true);
      

        }
    }

}
