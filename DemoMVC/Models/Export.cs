namespace DemoMVC.Models
{
    public class Export
    {
        public int Id { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public List<ExportDetail> ExportDetails { get; set; } = new();
    }
}