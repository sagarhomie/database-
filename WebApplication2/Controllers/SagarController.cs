using Microsoft.AspNetCore.Mvc;
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
            List<Student> students = new List<Student>();
            students = sagarContext.Students.ToList();
            return View(students);

        }
        [HttpGet]
        public IActionResult CreateStudent()
        {
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
            Student student = sagarContext.Students.Where(x=>x.Id==studentId).FirstOrDefault();
            sagarContext.Students.Remove(student);
            sagarContext.SaveChanges();
            return RedirectToAction("Students");
        }
    }
}
