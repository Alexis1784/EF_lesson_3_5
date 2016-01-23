using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EF_lesson_3_5
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SoccerContext db = new SoccerContext())
            {
                // создание и добавление моделей
                Player pl1 = new Player { Name = "Роналду", Age = 31, Position = "Нападающий" };
                Player pl2 = new Player { Name = "Месси", Age = 28, Position = "Нападающий" };
                Player pl3 = new Player { Name = "Хави", Age = 34, Position = "Полузащитник" };
                db.Players.AddRange(new List<Player> { pl1, pl2, pl3 });
                db.SaveChanges();

                Team t1 = new Team { Name = "Барселона" };
                t1.Players.Add(pl2);
                t1.Players.Add(pl3);
                Team t2 = new Team { Name = "Реал Мадрид" };
                t2.Players.Add(pl1);
                db.Teams.Add(t1);
                db.Teams.Add(t2);
                db.SaveChanges();
                foreach (Team t in db.Teams.Include(t => t.Players))
                {
                    Console.WriteLine("Команда: {0}", t.Name);
                    foreach (Player pl in t.Players)
                    {
                        Console.WriteLine("{0} - {1}", pl.Name, pl.Position);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }
    }
}
