using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderServices.Model
{
    //[Table("orders")]
    //public record OrderModel
    //{
    //    [Key]
    //    [Column("id")]
    //    public int Id { get; set; }

    //    [Required]
    //    [Column("product")]
    //    [StringLength(100)]
    //    public string product { get; set; } = string.Empty;

    //    [Column("order_date")]
    //    public DateTime OrderDate { get; set; } = DateTime.Now;

    //    [Column("quantity")]
    //    public int Quantity { get; set; } 

    //    [Column("price")]
    //    public decimal Price { get; set; }



    //};

    public record OrderModel(int Id, string Name, string ProductName);
}
