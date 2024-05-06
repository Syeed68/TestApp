using System.ComponentModel.DataAnnotations;

namespace TestProjectApi.Models
{
    public class EmployeeInfo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public string Photo { get; set; }
    }
}
