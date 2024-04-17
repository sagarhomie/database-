using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;

namespace WebApplication2.Controllers
{
    public class SagarController : Controller
    {
        SagarContext sagarContext;
        public SagarController(SagarContext sagarContext)
        {
            this.sagarContext = sagarContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Students()
        {
            string username = HttpContext.Session.GetString("username");
            ViewBag.Username = username;

            string accessDate = HttpContext.Request.Cookies["firstattemptdate"];
            ViewBag.Username = username;
            List<Student> students = new List<Student>();
            students = sagarContext.Students.ToList();
            ViewBag.todaydate=DateTime.Now.ToShortDateString();
            ViewData["todayTime"]=DateTime.Now.TimeOfDay;
            TempData["todayday"] = DateTime.Now.DayOfWeek;

            return View(students);

        }
        public IActionResult Studentss()
        {
            string username = HttpContext.Session.GetString("username");
            ViewBag.Username = username;
            List<Student> students = new List<Student>();
            students = sagarContext.Database.SqlQueryRaw<Student>(@"select * from student").ToList();
            return View("Students",students);

        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
            string username = HttpContext.Session.GetString("username");
            ViewBag.Username = username;
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            sagarContext.Students.Add(student);
            sagarContext.SaveChanges();
            return RedirectToAction("Students");
        }

        public IActionResult DeleteStudent(int studentId)
        {
            string username = HttpContext.Session.GetString("username");
            ViewBag.Username = username;
            Student student = sagarContext.Students.Where(x=>x.Id==studentId).FirstOrDefault();
            sagarContext.Students.Remove(student);
            sagarContext.SaveChanges();
            return RedirectToAction("Students");
        }
    }
}
