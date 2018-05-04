using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MonsterDB.Models;

namespace MonsterDB.DAL
{
    public class MonsterInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<MonsterContext>
    {
        protected override void Seed(MonsterContext context)
        {
            var monsters = new List<Monster>
            {
                new Monster{ Monster_ID = 1001, Monster_Name = "Scropion", Monster_HP = 1109, Monster_Race = "Insect", Monster_Property = "Fire 1"},
                new Monster{ Monster_ID = 1002, Monster_Name = "Poring", Monster_HP = 50, Monster_Race = "Formless", Monster_Property = "Water 1"},
                new Monster{ Monster_ID = 1004, Monster_Name = "Hornet", Monster_HP = 169, Monster_Race = "Insect", Monster_Property = "Wind 1"}                
            };

            monsters.ForEach(s => context.Monsters.Add(s));
            context.SaveChanges();

            //base.Seed(context);
        }
    }
}