using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    class Shop
    {
        protected String[] Slots=new string[10];

        public Shop()
        {
            
                Random rand = new Random();
                String[] items = new string[] { "Бутылка", "Парализующая каска", "Отравленный стилет", "Святой фрукт", "Книга знаний", "Целебная трава" };
                String[] spells = new string[] { "Заклинание полного исцеления", "Заклинание телепорта", "Заклинание катаклизм", "Заклиание ЭМП" };
                for (int i = 0; i < Slots.Length; i++)
                {
                    int or = rand.Next(0, 2);
                    if(or==0)
                        Slots[i] = items[rand.Next(0, 6)];
                    else
                        Slots[i] = spells[rand.Next(0, 4)];
                }
            

        }

        private delegate void indexes(Hero p, Enemy e, bool used);

        public void AddItem(Hero p)
        {
            ShowShop();
            int choose;
            while (true)
            {
                bool check = Int32.TryParse(Console.ReadLine(), out choose);

                if (!check)
                    Console.WriteLine("Неверные данные! Введите еще раз.");
                else
                {
                    if (choose>=1&&choose<12)
                        break;
                    else
                        Console.WriteLine("Неверное значение, введите еще раз!");
                }
            }
            if (choose == 11)
                return;
            BuyItem(choose, p);
            return;
        }

        public void ShowShop()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, 0);
            Console.WriteLine("*МАГАЗИН*");
            for (int i = 0; i < Slots.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Slots[i]}");
            }
            Console.WriteLine(Slots.Length + 1 + ") НАЗАД");
        }

        public void BuyItem(int index, Hero p)
        {
            if(GetSlot(index).Contains("Заклинание"))
            {
                p.spellsInventory.AddSpell(GetSlot(index),p);
            }
            else
            {
                p.inventory.AddItem(GetSlot(index), p);
            }
            return;
        }

        protected String GetSlot(int index)
        {
            return Slots[index];
        }
    }
}

