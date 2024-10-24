using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAnnotations.Entity;

[Table("Orders")]
public class Order
{
    public Order(string productName, int quantity, double price, int userId)
    {
        ProductName = productName;
        Quantity = quantity;
        Price = price;
        UserId = userId;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string ProductName { get; set; }
    [Required]
    public int Quantity { get; set; }
    [Required]
    public double Price { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public User User { get; set; }
    
}