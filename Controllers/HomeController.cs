using DECK_OF_CARDS_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DECK_OF_CARDS_API.Controllers
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
            return View();
        }

        public IActionResult DeckOfCards()
        {
            CardModel result = DeckOfCardsDAL.GetCards();
            if(result.success==false || result.remaining <5)
            {
                DeckOfCardsDAL.ShuffleCards();
                return View(result);
            }
            else
            {
                return View(result);
            }
            //return View(DeckOfCardsDAL.GetCards());
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