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
            //call API, pass value into View and view cards
            CardModel result = DeckOfCardsDAL.GetCards();
            if (result.remaining == 0)
            {
                DeckOfCardsDAL.ShuffleCards();
                return View(result);
            }
            return View(result);
        }

        public IActionResult Shuffle()
        {
            DeckOfCardsDAL.ShuffleCards();
            return RedirectToAction("DeckOfCards");  //string needs to match one of the methods
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