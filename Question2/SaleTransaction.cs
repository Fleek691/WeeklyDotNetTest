namespace Sales
{
/// <summary>
/// Core Entity Class
/// </summary>
public class SaleTransaction
{
    //get and set accessors for the fields
    public string InvoiceNo{get;set;}
    public string CustomerName{get;set;}
    public string ItemName {get;set;}
    public int Quantity{get;set;}
    public decimal PurchaseAmount{get;set;}
    public decimal SellingAmount{get;set;}
    public string ProfitOrLossStatus{get;set;}
    public decimal ProfitOrLossAmount{get;set;}
    public decimal ProfitMarginPercent{get;set;}
}
/// <summary>
/// Class for functionalities of the menu system
/// </summary>
public class Service
{
    public static SaleTransaction LastTransaction;//static storage variable to store last transaction
    public static bool HasLastTransaction=false;
    /// <summary>
    /// Method for creating new transaction
    /// </summary>
    public void CreateNewTransaction()
    {
        SaleTransaction transaction=new SaleTransaction();

        System.Console.Write("Enter Invoice Number: ");
        transaction.InvoiceNo=Console.ReadLine();
        if (string.IsNullOrEmpty(transaction.InvoiceNo))
        {
            System.Console.WriteLine("Invalid Invoice Number");
            return;
        }

        System.Console.Write("Enter Customer Name: ");
        transaction.CustomerName=Console.ReadLine();

        System.Console.Write("Enter Item Name: ");
        transaction.ItemName=Console.ReadLine();

        // Prompt and validate quantity
        System.Console.Write("Enter Quantity: ");
        if(!int.TryParse(Console.ReadLine(),out int quantity) || quantity <=0)
        {
            System.Console.WriteLine("Enter valid Quantity.");
            return;
        }
        transaction.Quantity=quantity;

        // Prompt and Purchase selling amount
        System.Console.Write("Enter Purchase Amount: ");
        if(!int.TryParse(Console.ReadLine(),out int purchase) || purchase <= 0)
        {
            System.Console.WriteLine("Enter valid Purchase Amount.");
            return;
        } 
        transaction.PurchaseAmount=purchase;

        // Prompt and validate selling amount
        System.Console.Write("Enter Selling Amount: ");
        if(!int.TryParse(Console.ReadLine(),out int selling) || selling <= 0)
        {
            System.Console.WriteLine("Enter valid Selling Amount.");
            return;
        } 
        transaction.SellingAmount=selling;

        // Calculate profit/loss
        CalculateProfitLoss(transaction);
        LastTransaction=transaction;
        HasLastTransaction=true;

        System.Console.WriteLine("Transaction Saved!!");
        // Print calculation results
        PrintCalculation(transaction);
    }
    /// <summary>
    /// Method for viewing last transaction if present
    /// </summary>
    public void ViewLastTransaction()
        {
            // Check if transaction exists
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available,Please create new transaction");
                return;
            }

            // Display transaction details
            Console.WriteLine("================Last Transaction ================");
            Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
            Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
            Console.WriteLine($"Item: {LastTransaction.ItemName}");
            Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
            Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount}");
            Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount}");
            Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount}");
            Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent}");
            Console.WriteLine("================================");
        }
    /// <summary>
    /// Method for re calculating the profit or loss margin if data present
    /// </summary>
    public void ReCalulate()
        {
            // Check if transaction exists
            if (!HasLastTransaction)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            CalculateProfitLoss(LastTransaction);
            // Print results
            PrintCalculation(LastTransaction);
        }

        /// <summary>
        /// Calculates the profit or loss based on purchase and selling amounts.
        /// </summary>
        /// <param name="transaction">The sale transaction to calculate for.</param>
        private void CalculateProfitLoss(SaleTransaction transaction)
        {
            if (transaction.SellingAmount > transaction.PurchaseAmount)
            {
                transaction.ProfitOrLossStatus = "PROFIT";
                transaction.ProfitOrLossAmount = transaction.SellingAmount - transaction.PurchaseAmount;
            }
            else if (transaction.SellingAmount < transaction.PurchaseAmount)
            {
                transaction.ProfitOrLossStatus = "LOSS";
                transaction.ProfitOrLossAmount = transaction.PurchaseAmount - transaction.SellingAmount;
            }
            else
            {
                transaction.ProfitOrLossStatus = "NONE";
                transaction.ProfitOrLossAmount = 0;
            }

            // Calculate profit margin percentage
            transaction.ProfitMarginPercent =(transaction.ProfitOrLossAmount / transaction.PurchaseAmount) * 100;
        }

        /// <summary>
        /// Method for printing Calculation
        /// </summary>
        /// <param name="transaction"></param>

        private void PrintCalculation(SaleTransaction transaction)
        {
            Console.WriteLine($"Status: {transaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {transaction.ProfitOrLossAmount}");
            Console.WriteLine($"Profit Margin (%): {transaction.ProfitMarginPercent}");
            Console.WriteLine("=============================================");
        }
    }
}