using Microsoft.AspNetCore.Mvc;
using ExperiencePost.Models;
using ExperiencePost.Repo;
using Microsoft.EntityFrameworkCore;

namespace ExperiencePost.Controllers
{
    public class ExperiencePostController : Controller
    {
        private readonly IEmployeeRepo _employeerepo;
        
        public ExperiencePostController(IEmployeeRepo employeerepo)
        {
            _employeerepo = employeerepo;
        }
        public IActionResult Index()
        {
            //Here html page would have sign up and login form
            return View();
        }

        //Register's get method is same as Index's view

        [HttpPost]
        public IActionResult Register(Employee obj)
        {
            _employeerepo.AddEmp(obj);

            //Put registraion success in  Viewbag or Viewdata

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Login(LoginModel obj)
        {
            //For Later

            //Put registraion success in  Viewbag or Viewdata

            Employee emp = _employeerepo.GetEmpByEmail(obj.Email);

            if(emp == null)
            {
                return View(); //Basically incorrect Email
            }

            if (emp.Password != obj.Password)
            {
                return View(); //Basically incorrect Password
            }

            //We are passing Empid . If changes are made , subsequent changes needs to be made in all function which redirects to Index

            return RedirectToAction("Details",emp.EmpID);
        }

        public IActionResult Details(int id)
        {
            if (id < 0)
            {
                return NotFound();
            }
            var Employee = _employeerepo.GetEmployeeByID(id);

            if (Employee == null)
            {
                return NotFound();
            }

            var Skills = _employeerepo.GetAllSkill(id);

            // https://www.c-sharpcorner.com/UploadFile/ff2f08/multiple-models-in-single-view-in-mvc/


            ViewBag.Employee = Employee;
            ViewBag.Skills = Skills;

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee emp = _employeerepo.GetEmployeeByID(id);
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _employeerepo.UpdateEmp(obj);
            return RedirectToAction("Details",obj.EmpID);
        }

        [HttpPost]
        public IActionResult DeleteSkill(int Skillid)
        {

            int id = _employeerepo.GetEmpBySkillId(Skillid);
            _employeerepo.Delete_Skill(Skillid);
            return RedirectToAction("Details",id);
        }

        [HttpGet]
        public IActionResult AddSkill(int id)
        {
            Skill skill = new Skill();
            skill.EmpID = id;
            return View(skill);
        }

        [HttpPost]
        public IActionResult AddSkill(Skill obj)
        {
            int id = _employeerepo.GetEmpBySkillId(obj.SkillId);
            _employeerepo.AddSkill(obj);
            return RedirectToAction("Details",id);
        }

    }
}
