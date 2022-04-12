using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    [Serializable]
    class Inventory : Artifacts
    {
        protected String[] Slots = new string[] { "Пусто", "Пусто", "Пусто", "Пусто", "Пусто" };

        public Inventory(bool heroInv)
        {
            if(heroInv)
                Slots = new string[] { "Пусто", "Пусто", "Пусто", "Пусто", "Пусто" };
            else
            {
                Random rand = new Random();
                String[] items = new string[] { "Бутылка", "Парализующая каска", "Отравленный стилет", "Святой фрукт", "Книга знаний", "Целебная трава" };
                for (int i = 0; i < Slots.Length; i++)
                {
                    Slots[i] = items[rand.Next(0, 6)];
                }
            }

    }

        private delegate void indexes(Hero p,Enemy e,bool used);

        public void AddItem(String name,Hero p,Enemy e,bool used)
        {
            if(Slots.Contains("Пусто"))
            {
                Slots[Array.FindIndex(Slots, x => x == "Пусто")] = name;
                return;
            }
            else
            {
                while (true)
                {
                    Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                    Console.WriteLine("Инвентарь полон, выберите нужное действие");
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2);
                    Console.WriteLine("1 - использовать предмет 2 - выкинуть предмет 3 - не брать предмет");
                    int choose;
                    while (true)
                    {
                        bool check = Int32.TryParse(Console.ReadLine(), out choose);

                        if (!check)
                            Console.WriteLine("Неверные данные! Введите еще раз.");
                        else
                        {
                            if (choose == 1 || choose == 2 || choose == 3)
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
                                    if (choose >= 1 && choose <= 6)
                                        break;
                                    else
                                        Console.WriteLine("Неверное значение, введите еще раз!");
                                }
                            }
                            if (choose == 6)
                                continue;
                            
                            UseItem(choose-1, p, e, used);//
                            break;
                        case 2:
                            ShowInventory();
                            while (true)
                            {
                                bool check = Int32.TryParse(Console.ReadLine(), out choose);

                                if (!check)
                                    Console.WriteLine("Неверные данные! Введите еще раз.");
                                else
                                {
                                    if ((choose >= 1 && choose <= 6))
                                        break;
                                    else
                                        Console.WriteLine("Неверное значение, введите еще раз!");
                                }
                            }
                            if (choose == 6)
                                continue;
                            if (DropItem(choose))
                                break;
                            else
                                AddItem(name, p, e, used);
                            break;
                        case 3:
                            return;
                            break;
                        default:
                            break;
                    }
                }
                return;
            }
        }
        public void AddItem(String name, Hero p)
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
                    Console.WriteLine("Инвентарь полон, выберите нужное действие");
                    Console.SetCursorPosition((Console.WindowWidth / 2) - 10, Console.WindowHeight / 2);
                    Console.WriteLine("1 - выкинуть предмет 2 - не брать предмет");
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
                                    if ((choose >= 1 && choose <= 6))
                                        break;
                                    else
                                        Console.WriteLine("Неверное значение, введите еще раз!");
                                }
                            }
                            if (choose == 6)
                                continue;
                            if (DropItem(choose))
                                break;
                            else
                                AddItem(name, p);
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
        public bool DropItem(int index)
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
                    if (choose ==1 || choose==2)
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
            Console.WriteLine("*СУМКА*");
            for (int i = 0; i < Slots.Length; i++)
            {
                Console.WriteLine($"{i+1}) {Slots[i]}");
            }
            Console.WriteLine(Slots.Length+1+") НАЗАД");
        }

        public void UseItem(int index,Hero p,Enemy e,bool used)
        {
            indexes[] ind=new indexes[] {Bottle,BookOfKnowledge,HolyFruit,StiletOfPoison,HealingVerb,ParalyzingCask };

            switch (Slots[index])
            {
                case "Бутылка":
                    ind[0](p, e, used);
                    break;
                case "Книга знаний":
                    ind[1](p, e, used);
                    break;
                case "Святой фрукт":
                    ind[2](p, e, used);
                    break;
                case "Отравленный стилет":
                    ind[3](p, e, used);
                    break;
                case "Целебная трава":
                    ind[4](p, e, used);
                    break;
                case "Парализующая каска":
                    ind[5](p, e, used);
                    break;
                default:
                    Events.OpenInventory(p,e);
                    break;
            }
            if (used)
                Slots[index] = "Пусто";
            return;
        }

        public String GetSlot(int index)
        {
            return Slots[index];
        }
    }
}
