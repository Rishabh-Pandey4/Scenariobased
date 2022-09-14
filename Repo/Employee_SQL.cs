using ExperiencePost.Models;

namespace ExperiencePost.Repo
{
    public class Employee_Sql : IEmployeeRepo
    {
         EmployeeDbContext context;
        public Employee_Sql(EmployeeDbContext context)
        {
            this.context = context;

        }
        public Employee AddEmp(Employee employee)
        {
            context.Employees.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public void AddSkill(Skill skill)
        {
            context.Skills.Add(skill);
            context.SaveChanges();

        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();

            }
            return employee;

        }

        public void Delete_Skill(int id)
        {
            Skill skill = context.Skills.Find(id);
            if (skill != null)
            {
                context.Skills.Remove(skill);
                context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            IEnumerable<Employee> employees = context.Employees;

            return context.Employees;
        }

        public IEnumerable<Skill> GetAllSkill(int Id)
        {
            return context.Skills.Where(s => s.EmpID == Id).ToList<Skill>();


        }

        public Employee GetEmployee(Employee employee)
        {
            return context.Employees.FirstOrDefault(e => e.Email == employee.Email && e.Password == employee.Password);

        }

        public Employee GetEmployeeByID(int id)
        {

            return context.Employees.FirstOrDefault(e => e.EmpID == id);
        }

        public Skill GetSkill(int Id)
        {
            return context.Skills.FirstOrDefault(s => s.SkillId == Id);
        }

        public Employee UpdateEmp(Employee employeeChanges)
        {
            Employee employee = context.Employees.FirstOrDefault(e => e.EmpID == employeeChanges.EmpID);
            if (employee != null)
            {
                employee.FirstName = employeeChanges.FirstName;
                employee.LastName = employeeChanges.LastName;
                employee.Password = employeeChanges.Password;
                employee.CellNumber = employeeChanges.CellNumber;
                employee.Email = employeeChanges.Email;

            }
            var emp = context.Employees.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();

            return employee;


        }
        int GetEmpBySkillId(int SKillid)
        {
            Skill skill = context.Skills.Find(SKillid);
            return skill.EmpID;
        }

        Employee GetEmpByEmail(String Email)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.Email == Email);
            return emp;
        }
    }
}
