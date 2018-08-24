using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;
using DraftChat.Models;
using System.Linq;
using System.Collections.Generic;

namespace DraftChat.Hubs
{
    public class ChatHub : Hub
    {

        private DraftChatContext _context;
        public ChatHub(DraftChatContext context)
        {
            _context = context;
        }
        
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendPick(string user, string player)
        {
            await Clients.All.SendAsync("ReceivePick", user, player);
        }

        public async Task UpdateTimer(string counter)
        {
            await Clients.All.SendAsync("ReceiveTimer", counter);
        }

        public async Task UpdateDb(int userId, int playerId)
        {
            Player DraftedPlayer = _context.Players.SingleOrDefault(p => p.PlayerId == playerId);
            FantasyTeam PickingTeam = _context.FantasyTeams.SingleOrDefault(f => f.FantasyTeamId == userId);
            PickingTeam.Players.Add(DraftedPlayer);
            _context.SaveChanges();        
            await Clients.All.SendAsync("ReceiveDb", userId, playerId);
        }

        public async Task UpdateTurn(int teamId)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("teamId: " + teamId);
            System.Console.WriteLine();
            List<FantasyTeam> allFantasyTeams = _context.FantasyTeams.ToList();
            // List<FantasyTeam> allFantasyTeamsReversed = _context.FantasyTeams.ToList();
            // allFantasyTeamsReversed.Reverse();
            // allFantasyTeams.AddRange(allFantasyTeamsReversed);
            
            int next = -1;
            for(int i =0; i< allFantasyTeams.Count; i++){
                if(allFantasyTeams[i].FantasyTeamId == teamId){
                    
                    System.Console.WriteLine(i);
                    System.Console.WriteLine(allFantasyTeams.Count-1);
                    if(i==allFantasyTeams.Count-1){
                        next = 0;
                        break;
                    }else{
                        next = i +1;
                    }                   
                }
            }

            await Clients.All.SendAsync("ReceiveNewCurrentTeam", allFantasyTeams[next].FantasyTeamId); 

        }
    }
}