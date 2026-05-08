using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Supplier
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        public string? Address { get; set; }

        public List<Import> Imports { get; set; } = new();
    }
}