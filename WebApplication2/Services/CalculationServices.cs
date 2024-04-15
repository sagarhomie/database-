using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class CalculationServices
    {
        public NumberModel AddTwoNumbers(NumberModel numberModel)
        {
            numberModel.Result= numberModel.FirstNumber + numberModel.SecondNumber;
            return numberModel;
        }
    }
}
