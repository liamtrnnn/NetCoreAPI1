  using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nhập tên đi")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Nhập số điện thoại")]
        public string Phone { get; set; } = "";

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}