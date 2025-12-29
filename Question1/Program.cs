namespace MediSure{
public class Program
{
    /// <summary>
    /// Main method 
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        string choice;
        BillingService medicalservice=new BillingService();
        do//do while loop for menu system 
        {
            System.Console.WriteLine("====================MediSure Clinic Billing====================");
            System.Console.WriteLine("1. Create New Bill");
            System.Console.WriteLine("2. View Last Bill");
            System.Console.WriteLine("3. Clear Last Bill");
            System.Console.WriteLine("4. Exit");
            System.Console.Write("Enter your choice: ");
            choice=Console.ReadLine();
            switch (choice)
            {
                case "1":
                    medicalservice.NewBill();
                    break;
                case "2":
                    medicalservice.ViewLastBill();
                    break;
                case "3":
                    medicalservice.ClearLastBill();
                    break;
                case "4":
                    System.Console.WriteLine("Thankyou for your service!!");
                    break;
                default:
                    System.Console.WriteLine("Invalid Choice, Please enter again!");
                    break;
            }
        }while(choice!="4");//if user selects 4 then console app exits
        
    }
}
}