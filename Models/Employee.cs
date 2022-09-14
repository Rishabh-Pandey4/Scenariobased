using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExperiencePost.Models
{
    public class Employee
    {

        /*  public int EmployeeId { get; set; }
          public string Employee_Name { get; set; }
          public string Job { get; set; }
          public int Sal { get; set; }
          public int Deptno { get; set; }*/
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpID { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please Enter First Name e.g. John")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name e.g. Doe")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Password should not be blank")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [DisplayName("Cell Number")]
        [Required(ErrorMessage = "Cell Number should not be blank")]

        public string CellNumber { get; set; }
        [Required(ErrorMessage = "Enter valid email address")]
        [EmailAddress]
        public string Email { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
         : base(options)
        {

        }
    }
}