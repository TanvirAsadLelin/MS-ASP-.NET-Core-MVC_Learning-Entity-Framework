using System.ComponentModel.DataAnnotations;
namespace CRUD_CodeFirstApproach_EFCore.Models
{
    public class Employee
    {   
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Gender { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
    }
}
