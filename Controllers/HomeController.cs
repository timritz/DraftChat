using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DraftChat.Models;

namespace DraftChat.Controllers
{
    public class HomeController : Controller
    {

        private DraftChatContext _context;
        public HomeController(DraftChatContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Player> ListPlayers = _context.Players.ToList();
            return View(ListPlayers);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
