using Microsoft.AspNetCore.Mvc;
using PasswordGenerative.Models;
using System.Text;

namespace PasswordGenerative.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new PasswordModel());
            // return View();
        }


        [HttpPost]
        public IActionResult Generate(PasswordModel model)
        {
            if (model.Length > 25)
            {
                ViewBag.ErrorLength = "The random you would generate is an exceeded!.\r\n\r\n";
                return View("Index", model);
            }
            model.GeneratedPassword = GenerateUniquePassword(model.Length);
            return View("Index", model);
        }

        private string GenerateUniquePassword(int length)
        {
            //const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            // const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!_@#$";
            const string validChars = "1234567890";
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            HashSet<char> usedChars = new HashSet<char>();

            while (password.Length < length)
            {
                char randomChar = validChars[random.Next(validChars.Length)];

                if (!usedChars.Contains(randomChar))
                {
                    usedChars.Add(randomChar);
                    password.Append(randomChar);
                }
            }
            return password.ToString();
        }
    }
}
