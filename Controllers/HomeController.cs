using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
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
            HttpContext.Session.SetInt32("CurrentUserId", 69);
            List<Player> ListPlayers = _context.Players.ToList();
            return View(ListPlayers);
        }

        public int? About()
        {
            ViewData["Message"] = "Your application description page.";

            return HttpContext.Session.GetInt32("CurrentUserId");
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
