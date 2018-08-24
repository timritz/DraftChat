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

        public async Task SendPick(int FantasyTeamId, string player)
        {
            FantasyTeam YourTeam = _context.FantasyTeams.SingleOrDefault(t => t.FantasyTeamId == FantasyTeamId);
            await Clients.All.SendAsync("ReceivePick", YourTeam.TeamName, player);
        }

        public async Task UpdateTimer(string counter)
        {
            await Clients.All.SendAsync("ReceiveTimer", counter);
        }

        public async Task UpdateDb(int FantasyTeamId, int playerId)
        {
            Player DraftedPlayer = _context.Players.SingleOrDefault(p => p.PlayerId == playerId);
            FantasyTeam PickingTeam = _context.FantasyTeams.SingleOrDefault(f => f.FantasyTeamId == FantasyTeamId);
            PickingTeam.Players.Add(DraftedPlayer);
            _context.SaveChanges();        
            await Clients.All.SendAsync("ReceiveDb", FantasyTeamId, playerId);
        }

        public async Task NewTeam(int TeamId)
        {
            FantasyTeam team = _context.FantasyTeams.SingleOrDefault(t => t.FantasyTeamId == TeamId);
            string FantasyTeamName = team.TeamName;
            await Clients.All.SendAsync("ReceiveNewTeam", FantasyTeamName,TeamId);
        }
        
        bool iteratingDownList = true;
        public async Task UpdateTurn(int teamId)
        {
            System.Console.WriteLine();
            System.Console.WriteLine("teamId: " + teamId);
            System.Console.WriteLine("iterating down: " + iteratingDownList);
            System.Console.WriteLine();
            List<FantasyTeam> allFantasyTeams = _context.FantasyTeams.ToList();
            
            int next = -1;
            for(int i =0; i< allFantasyTeams.Count; i++){
                if(allFantasyTeams[i].FantasyTeamId == teamId){
                    if(iteratingDownList){
                        System.Console.WriteLine(i);
                        System.Console.WriteLine(allFantasyTeams.Count-1);
                        if(i==allFantasyTeams.Count-1){
                            next = 0;
                            iteratingDownList = false;
                            System.Console.WriteLine("iterating down during: " + iteratingDownList);
                        }else{
                            next = i +1;
                        }
                    } else{
                        if(i==0){
                            next = i;
                            iteratingDownList = true;
                        }else{
                          next = i -1;  
                        }
                        
                    }
                    
                }
            }

            System.Console.WriteLine("iterating down before return: " + iteratingDownList);

            await Clients.All.SendAsync("ReceiveNewCurrentTeam", allFantasyTeams[next].FantasyTeamId); 

        }
    }
}