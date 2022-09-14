using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ExperiencePost.Models
{
    public class Skill
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        [ForeignKey("ClsEmployee")]
        public int EmpID { get; set; }
        [DisplayName("Skill Name")]
        [Required(ErrorMessage = "Skill name should not be blank")]
        public string SkillName { get; set; }
        [Required(ErrorMessage = "Employee Role should not be blank")]
        [DisplayName("Role")]
        public string Role { get; set; }
        [DisplayName("Experience In Years")]
        [Required(ErrorMessage = "Experience in years should not be blank")]
        public int ExperienceInYears { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}