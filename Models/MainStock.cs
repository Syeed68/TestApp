using System.ComponentModel.DataAnnotations;

namespace TestProjectApi.Models
{
    public class MainStock
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public decimal Qty { get; set; }
        public decimal Price { get; set; }
    }
}
