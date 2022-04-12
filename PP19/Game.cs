using System;

namespace PP19
{
    class Game
    {
        public static Hero[] savePlayers = new Hero[3] { new Hero(), new Hero(), new Hero() };
        private static int Step { get; set; }
        public static bool GameRunning = true, isMenu = true;
        public static Hero hero = new Hero();
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            while (GameRunning)
            {
                while (isMenu)
                {
                    hero = Menu._Menu();
                    Stats.LoadStats();
                    isMenu = false;
                }
                Random rand = new Random();
                int chance = rand.Next(1, 101);

                if (chance >= 1 && chance <= 36)
                {
                    if (Events.fightWithEnemy(hero, new Enemy()) == 1)
                    {
                        isMenu = true;
                    }
                }
                else if (chance >= 35 && chance <= 55)
                {
                    if (Events.FindChest(hero) == 1)
                    {
                        isMenu = true;
                    }
                }
                else if (chance >= 55 && chance <= 75)
                {
                    Events.SafeZone(hero, shop);
                }
                else if (chance >= 75 && chance <= 85)
                {
                    if(Events.Trap(hero)==1)
                    {
                        isMenu = true;
                    }

                }
                else
                {
                    if(Events.fightWithKing(hero)==1)
                    {
                        isMenu = true;
                    }
                    else
                    {
                        Stats.allStats[BuildPlayer.PIndex].bossesKilled++;
                    }
                }
                Step++;
                Stats.SaveStats();
                Stats.TextStats();
            }
        }
    }
        }
    

