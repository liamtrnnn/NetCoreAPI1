namespace DemoMVC.Models
{
    public class Import
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int SupplierId { get; set; }

        public Supplier? Supplier { get; set; }

        public List<ImportDetail> ImportDetails { get; set; } = new();
    }
}