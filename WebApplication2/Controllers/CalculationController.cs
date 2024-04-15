using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    public class CalculationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddTwoNumbers() { 
            NumberModel model = new NumberModel();  
            return View(model);
        }
        [HttpPost]
        public IActionResult AddTwoNumbers(NumberModel numbers)
        {
         CalculationServices calculationService= new CalculationServices();
            NumberModel model = calculationService.AddTwoNumbers(numbers);
            return View (model);
          
        }
    }
}
