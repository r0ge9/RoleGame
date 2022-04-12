using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    class WraithKing : Enemy
    {
        public WraithKing()
        {
            Random rand = new Random();
            Name = "WraithKing";
            MaxHP = rand.Next(300,500);
            HP = MaxHP;
            MaxMana = rand.Next(300, 500);
            Mana = MaxMana;
        }

        public new int Hit(Hero p)
        {
            Random rand = new Random();
            int dmg = 0;
            if (rand.Next(2, 101) < missChance)
                dmg= 0;
            else if (p.HP > p.MaxHP/2)
            {
                dmg= rand.Next(40, 91);
            }
            else if (p.HP > (p.MaxHP/2)/2 && p.HP < p.MaxHP/2)
                dmg= rand.Next(31, 51);
            else if (p.HP < (p.MaxHP / 2) / 2 && p.HP > 20)
                dmg= rand.Next(20, 31);
            else
            {
                dmg = rand.Next(2, 21);
                if (p.HP - dmg < 0)
                {
                    p.HP = 0;
                    return 1;
                }
                    
            }
            if (rand.Next(0, 101) < 20)
            {
                dmg = crit(dmg);
                return dmg;
            }
            else
                return dmg;
        }

        public  int crit(int dmg)
        {
            Console.ForegroundColor=ConsoleColor.Red;
            Console.WriteLine($"Критический удар! Вам нанесли {dmg*2} урона.");
            Console.ResetColor();
            return dmg * 2;
        }
        public  void skelet(Hero p)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Король поднял меч и около него из земли вылез скелет! Придется драться.");
            Console.ResetColor();
            Events.fightWithEnemy(p, new Enemy("Скелет"));
            return;
        }
    }
}
