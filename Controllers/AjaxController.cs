using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DraftChat.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace DraftChat.Controllers
{
    public class AjaxController : Controller
    {   
        private DraftChatContext _context;
        public AjaxController(DraftChatContext context)
        {
            _context = context;
        }


        [HttpGet]
        public PartialViewResult AllOfTeam(string team)
        {
            System.Console.WriteLine(team);
            List<Player> ListPlayers = _context.Players.Where(p => p.TeamName == team).ToList();
            System.Console.WriteLine(ListPlayers);
            return PartialView("~/Views/Shared/PlayerData.cshtml", ListPlayers);
        }

        [HttpGet]
        public PartialViewResult AllOfPos(string position)
        {
            System.Console.WriteLine(position);
            System.Console.WriteLine("I'm here!");
            List<Player> ListPlayers = _context.Players.Where(p => p.Position == position).ToList();
            return PartialView("~/Views/Shared/PlayerData.cshtml", ListPlayers);
        }

        [HttpGet]
        public PartialViewResult AllOfAvail()
        {
            List<Player> ListPlayers = _context.Players.Where(p => p.FantasyTeamId == null).ToList();
            return PartialView("~/Views/Shared/PlayerData.cshtml", ListPlayers);
        }

        [HttpGet]
        public PartialViewResult RosterUpdate(int FantasyTeamId)
        {
            FantasyTeam YourTeam = _context.FantasyTeams.Include(t => t.Players).SingleOrDefault(p => p.FantasyTeamId == FantasyTeamId);
            return PartialView("~/Views/Shared/RosterPartialAjax.cshtml",YourTeam);
        }

        [HttpGet]
        public PartialViewResult UpdateTable()
        {
            List<Player> ListPlayers = _context.Players.Include(p=> p.FantasyTeam).ToList();
            System.Console.WriteLine("Updatetable!!!!!!!!!!!!!");
            return PartialView("~/Views/Shared/PlayerData.cshtml", ListPlayers);
        }
    }
}