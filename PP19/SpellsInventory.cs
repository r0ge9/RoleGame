using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    [Serializable]
    class SpellsInventory : Spells
    {
        protected String[] Slots;

        private delegate void indexes(Hero p, Enemy e, bool used);

        public SpellsInventory(bool heroInv)
        {
            if (heroInv)
                Slots = new string[] { "Пусто", "Пусто"};
            else
            {
                Random rand = new Random();
                Slots = new string[2];
                String[] items = new string[] { "Заклинание полного исцеления", "Заклинание телепорта", "Заклинание катаклизм", "Заклиание ЭМП","Заклинание метеоритного дождя"};
                for (int i = 0; i < Slots.Length; i++)
                {
                    Slots[i] = items[rand.Next(0, 5)];
                }
            }

        }
        public void AddSpell(String name, Hero p)
        {
            if (Slots.Contains("Пусто"))
            {
                Slots[Array.FindIndex(Slots, x => x == "Пусто")] = name;
                return;
            }
            else
            {
                while (true)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.WriteLine("Все ячейки заняты, выберите нужное действие");
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2);
                    Console.WriteLine("1 - выкинуть заклинание 2 - не брать заклинание");
                    int choose;
                    while (true)
                    {
                        bool check = Int32.TryParse(Console.ReadLine(), out choose);

                        if (!check)
                            Console.WriteLine("Неверные данные! Введите еще раз.");
                        else
                        {
                            if (choose == 1 || choose == 2)
                                break;
                            else
                                Console.WriteLine("Неверное значение, введите еще раз!");
                        }
                    }
                    switch (choose)
                    {
                        case 1:
                            ShowInventory();
                            while (true)
                            {
                                bool check = Int32.TryParse(Console.ReadLine(), out choose);

                                if (!check)
                                    Console.WriteLine("Неверные данные! Введите еще раз.");
                                else
                                {
                                    if (choose != 6)
                                    {
                                        if ((choose>= 1 && choose<= 3) && (p.spellsInventory.GetSlot(choose - 1) != "Пусто"))
                                            break;
                                        else
                                            Console.WriteLine("Неверное значение, введите еще раз!");
                                    }
                                    else
                                        break;
                                }
                            }
                            if (choose == 3)
                                continue;
                            if (DropSpell(choose))
                                break;
                            else
                                AddSpell(name,p);
                            break;
                        case 2:
                            return;
                            break;
                        default:
                            break;
                    }
                }
                return;
            }
        }
        public bool DropSpell(int index)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Вы уверены?");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("1 - да 2 - нет");
            int choose;
            while (true)
            {
                bool check = Int32.TryParse(Console.ReadLine(), out choose);

                if (!check)
                    Console.WriteLine("Неверные данные! Введите еще раз.");
                else
                {
                    if (choose == 1 || choose == 2)
                        break;
                    else
                        Console.WriteLine("Неверное значение, введите еще раз!");
                }
            }
            if (choose == 1)
            {
                Slots[index] = "Пусто";
                return true;
            }

            else
            {
                return false;
            }
        }

        public void ShowInventory()
        {
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2, 0);
            Console.WriteLine("*ЗАКЛИНАНИЯ*");
            for (int i = 0; i < Slots.Length; i++)
            {
                Console.WriteLine($"{i + 1}) {Slots[i]}");
            }
            Console.WriteLine(Slots.Length + 1 + ") НАЗАД");
        }

        public void UseSpell(int index, Hero p, Enemy e, bool used)
        {
            indexes[] ind = new indexes[] { FullHeal, Teleport, Cataclysm, EMP,MeteorHammer};

            switch (Slots[index])
            {
                case "Заклинание полного исцеления":
                    ind[0](p, e, used);
                    break;
                case "Заклинание телепорта":
                    ind[1](p, e, used);
                    break;
                case "Заклинание катаклизм":
                    ind[2](p, e, used);
                    break;
                case "Заклинание ЭМП":
                    ind[3](p, e, used);
                    break;
                case "Заклинание метеоритного дождя":
                    ind[4](p, e, used);
                    break;
                //case "Парализующая каска":
                //    ind[5](p, e, used);
                //    break;
                default:
                    Events.OpenSpells(p, e);
                    break;
            }
            return;
        }

        public String GetSlot(int index)
        {
            return Slots[index];
        }
    }
}
