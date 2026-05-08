using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public decimal Price { get; set; }   // 🔥 THÊM DÒNG NÀY

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; } = new(); // 🔥 THÊM
    }
}