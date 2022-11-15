namespace CarInvoiceGeneretor;
public class Program
{
    public static void Main(string[] args)
    {
        InvoiceGenerator invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
        double fare = invoiceGenerator.CalculateFare(2.0, 5);
        Console.WriteLine($"fare: {fare}");
    }
}