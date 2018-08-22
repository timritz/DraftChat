using Microsoft.EntityFrameworkCore;

namespace DraftChat.Models
{
    public class DraftChatContext : DbContext
    {
        public DraftChatContext(DbContextOptions<DraftChatContext> options) : base(options) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<FantasyTeam> FantasyTeams { get; set; }
    }
}