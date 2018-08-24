using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DraftChat.Models
{
    public class FantasyTeam
    {
        public int FantasyTeamId { get; set; }
        public double Wallet { get; set; }
        public string Password { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(13)]
        public string TeamName { get; set; }
        public List<Player> Players { get; set; }
        public FantasyTeam()
        {
            Players = new List<Player>();
            Wallet = 0;
            Password = "Password";
        }
    }
}