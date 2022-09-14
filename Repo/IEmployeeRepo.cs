using ExperiencePost.Models;

namespace ExperiencePost.Repo
{
    public interface IEmployeeRepo
    {
        Employee GetEmployee(Employee employee);
        IEnumerable<Employee> GetAllEmployee();
        Employee AddEmp(Employee employee);
        Employee GetEmployeeByID(int id);
        Employee UpdateEmp(Employee employeeChanges);
        Employee Delete(int id);
        Skill GetSkill(int Id);
        IEnumerable<Skill> GetAllSkill(int Id);
        void AddSkill(Skill skill);
        void Delete_Skill(int id);

        int GetEmpBySkillId(int SKillid);

        Employee GetEmpByEmail(String Email);
    }
}
