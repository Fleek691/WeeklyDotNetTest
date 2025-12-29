namespace MediSure
{
    

/// <summary>
/// Core entity containing all the feilds
/// </summary>
public class PatientBill
{
    //get and set accessors for the fields
    public string BillId {get;set;}
    public string Patientname {get;set;}
    public bool HasInsurance {get;set;}
    public decimal ConsultationFee{get;set;}
    public decimal LabCharges{get;set;}
    public decimal MedicalCharges {get;set;}
    public decimal GrossAmount{get;set;}
    public decimal DiscountAmount{get;set;}
    public decimal PayableAmount{get;set;}
}
/// <summary>
/// Provides billing services for creating, viewing, and clearing patient bills.
/// </summary>
public class BillingService
{
    public static PatientBill LastBill;//static storage variable to store last bill
    public static bool HasLastBill=false;

    /// <summary>
    /// Method for when user wants to create a bill
    /// </summary>
    public void NewBill()
    {
        // Create a new bill instance
        PatientBill bill=new PatientBill();
        System.Console.Write("Enter Bill Id: ");
        bill.BillId=Console.ReadLine();
        // Validate bill ID
        if (string.IsNullOrEmpty(bill.BillId))
        {
            Console.WriteLine("Invalid Bill Id!");
            return;
        }

        Console.Write("Enter Patient Name: ");
        bill.Patientname=Console.ReadLine();

        Console.Write("Does the patient have insurance? yes/no: ");
        string insurance=Console.ReadLine();
        // Set insurance flag based on input
        if (insurance == "yes")
        {
            bill.HasInsurance=true;
        }
        else
        {
            bill.HasInsurance=false;
        }

        Console.Write("Enter Consultation Fee: ");
        // Validate consultation fee
        if (!decimal.TryParse(Console.ReadLine(), out decimal consultationFee) || consultationFee <= 0)
        {
            System.Console.WriteLine("Invalid Consultation fee!!");
            return;
        }
        bill.ConsultationFee=consultationFee;

        System.Console.Write ("Enter Lab Charges: ");
        // Validate lab charges
        if(!decimal.TryParse(Console.ReadLine(), out decimal labCharges) || labCharges < 0)
        {
            System.Console.WriteLine("Invalid Lab Charges!");
            return;
        }
        bill.LabCharges=labCharges;

        System.Console.Write("Enter Medicine Charges: ");
        // Validate medicine charges
        if(!decimal.TryParse(Console.ReadLine(), out decimal medicineCharges) || medicineCharges < 0)
        {
            System.Console.WriteLine("Invalid Amount");
            return;
        }
        bill.MedicalCharges=medicineCharges;

        bill.GrossAmount=bill.ConsultationFee+bill.MedicalCharges+bill.LabCharges;

        // Calculate discount based on insurance
        if (bill.HasInsurance)
        {
            bill.DiscountAmount=bill.GrossAmount * 0.10m;
        }
        else
        {
            bill.DiscountAmount=0;
        }
        // Calculate payable amount after discount
        bill.PayableAmount=bill.GrossAmount-bill.DiscountAmount;
        // Store the bill as last bill
        LastBill=bill;
        HasLastBill=true;
        // Display success message and bill details
        Console.WriteLine($"Bill created successfully.");
        Console.WriteLine($"Gross AMount: {bill.GrossAmount}");
        System.Console.WriteLine($"Discount Amount: {bill.DiscountAmount}");
        System.Console.WriteLine($"Payable Amount: {bill.PayableAmount}");
    }

    /// <summary>
    /// Method to view last bill if available
    /// </summary>
    public void ViewLastBill()
    {
        // Check if a last bill exists
        if (!HasLastBill)
        {
            System.Console.WriteLine("No Bill available,create one first.");
        }
        else
        {
            // Display bill details in a formatted manner
            Console.WriteLine("\n================Last Bill================");
            Console.WriteLine($"BillId: {LastBill.BillId}");
            Console.WriteLine($"Patient: {LastBill.Patientname}");
            Console.WriteLine($"Insured: {(LastBill.HasInsurance ? "Yes" : "No")}");
            Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
            Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
            Console.WriteLine($"Medicine Charges: {LastBill.MedicalCharges:F2}");
            Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {LastBill.PayableAmount:F2}");
            Console.WriteLine("================================");
        }
    }
    /// <summary>
    /// Method to clear or erase last bill if available
    /// </summary>
    public void ClearLastBill()
    {
        // Check if a last bill exists
        if (HasLastBill == true)
        {
            // Clear the bill and reset the flag
            LastBill=null;
            HasLastBill=false;
            System.Console.WriteLine(" Last Bill Cleared.");
        }
        else
        {
            System.Console.WriteLine("No Bill available, create one first.");
        }
        
    }
}
}