using System.ComponentModel.DataAnnotations;

namespace TestProjectApi.Models
{
    public class SalesInfo
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string ProductName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
