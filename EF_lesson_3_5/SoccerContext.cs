using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace EF_lesson_3_5
{
    class SoccerContext : DbContext
    {
        public SoccerContext()
            : base("SoccerContext2")
        { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
