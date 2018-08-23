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
            System.Console.WriteLine("in team setup");
            return View("TeamCreate");
        }

        [HttpPost]
        [Route("")]
        public IActionResult ProcessTeamSetup(FantasyTeam newTeam)
        {
            
            System.Console.WriteLine("in process team setup");
            System.Console.WriteLine("model state: " + ModelState.IsValid);
            System.Console.WriteLine(newTeam.TeamName);
            
            if(ModelState.IsValid){

                _context.FantasyTeams.Add(newTeam);
                _context.SaveChanges();

                System.Console.WriteLine("going to Index");
                return RedirectToAction("DraftPage", new {TeamName = newTeam.TeamName, TeamId = newTeam.FantasyTeamId});
            }else{
                System.Console.WriteLine("returning to teamCreate");
                return View("TeamCreate");
            }

            
        }

        public IActionResult DraftPage(string TeamName, int TeamId)
        {
            System.Console.WriteLine("TeamName in Process: " + TeamName);

            List<Player> ListPlayers = _context.Players.ToList();
            List<FantasyTeam> ListTeams = _context.FantasyTeams.ToList();
            ViewBag.ListTeams = ListTeams;
            ViewBag.TeamName = TeamName;
            ViewBag.TeamId = TeamId;
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
