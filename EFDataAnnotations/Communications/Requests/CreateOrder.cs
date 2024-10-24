namespace EFDataAnnotations.Communications.Requests;

public class CreateOrder
{
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public int UserId { get; set; }
    
}