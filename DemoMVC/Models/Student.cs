using System.ComponentModel.DataAnnotations;

namespace DemoMVC.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(10, ErrorMessage = "Tối đa 10 ký tự")]
        public string? StudentCode { get; set; }

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string? FullName { get; set; }
    }
}