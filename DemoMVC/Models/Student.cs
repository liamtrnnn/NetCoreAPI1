using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? StudentCode { get; set; }

        public string? FullName { get; set; }
    }
}