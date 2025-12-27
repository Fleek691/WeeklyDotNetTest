class Program
    {
        /// <summary>
        /// Main method 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string choice;
            Service service = new Service();

            do//do while loop for menu system in console app
            {
                Console.WriteLine("\n================== QuickMart Traders ==================");
                Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        service.CreateNewTransaction();
                        break;

                    case "2":
                        service.ViewLastTransaction();
                        break;

                    case "3":
                        service.ReCalulate();
                        break;

                    case "4":
                        Console.WriteLine("Thank you for your service");
                        break;

                    default:
                        Console.WriteLine("Invalid Choice, Please enter again!");
                        break;
                }
            }while(choice!="4");//if user selects 4 then console app exits
        }
    }