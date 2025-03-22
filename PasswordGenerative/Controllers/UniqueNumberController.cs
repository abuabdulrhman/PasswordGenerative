using Microsoft.AspNetCore.Mvc;
using PasswordGenerative.Services.Internal;

namespace PasswordGenerative.Controllers
{
    public class UniqueNumberController : Controller
    {
        private readonly IUniqueNumberGeneratorService _uniqueNumberGeneratorService;

        public UniqueNumberController(IUniqueNumberGeneratorService uniqueNumberGeneratorService)
        {
            _uniqueNumberGeneratorService = uniqueNumberGeneratorService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GenerateNumber(int length)
        {
            if (length > 10)
            {
                ViewBag.MaxLengthError = "generated numbers exceeded 10 digits," + Environment.NewLine +
                                         "you can generate more than that but you will get a duplicate of the numbers.";
                return View("Index");
            }

            if (length <= 0)
            {
                return BadRequest("Length must be greater than zero");
            }
            string uniqueNumber = _uniqueNumberGeneratorService.GenerateUniqueNumbersNotStartWithZero(length);
            ViewBag.UniqueNumber = uniqueNumber;
            return View("Index");
        }
    }
}
