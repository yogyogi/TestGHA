using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestGHA.Models;

namespace TestGHA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string presidentInput, string playerInput, string personInput, string tennisInput)
        {
            // Comment to fail the test
            /*if (string.IsNullOrEmpty(presidentInput))
                ModelState.AddModelError("name", "Please enter your answer");
            if (string.IsNullOrEmpty(playerInput))
                ModelState.AddModelError("name", "Please enter your answer");
            if (string.IsNullOrEmpty(personInput))
                ModelState.AddModelError("name", "Please enter your answer");
            if (string.IsNullOrEmpty(tennisInput))
                ModelState.AddModelError("name", "Please enter your answer");*/

            if (ModelState.IsValid)
            {
                string president = "Donald Trump", player = "Christiano Ronaldo", person = "Elon Musk", tennis = "Novak Djokovic";
                int correct = 0;
                if (presidentInput == president)
                    correct++;
                if (playerInput == player)
                    correct++;
                if (personInput == person)
                    correct++;
                if (tennisInput == tennis)
                    correct++;

                string result = $"<p>You got {correct} answers correct</p><p>Here are the correct answers:</p><p>{president} is the president of United States</p><p>{player} has most international goals in football</p><p>{person} is the richest person in the world</p><p>{tennis} has won most Grand Slam titles in tennis</p>";
                return View((object)result);
            }
            else
                return BadRequest(ModelState);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
