using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    class Events
    {
        private static bool EscapeFromFight()
        {
            String[] succes = new string[]
            {
                "Вы взяли свой кирзач и кинули ему прямо в голову, что дало время уйти. Так держать!",
                "Не зря занимались кроссом в школе, существо не успело моргнуть, как ваш след простыл!",
                "Вы нащупали недоеденный кусок мяса с обеда и кинули его прямо под существо, оно переключило все свое внимание на него и вы успешно ушли!"
            };
            String[] fail = new string[]
            {
                "Сапог всего лишь двое, так что кидать уже было нечего, существо с радостью разорвало вас на части...",
                "Кросс прошел мимо вас в школе, так же как и ваша жизнь в эту секунду...",
                "В этот раз вы съели весь обед, поэтому существу достанется двойная порция..."
            };
            Random rand = new Random();
            if (rand.Next(0, 51) < 50)
            {
                Console.Clear();
                Console.SetCursorPosition(20, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fail[rand.Next(0, 3)]);
                Console.ResetColor();
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
                return false;
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(20, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(succes[rand.Next(0, 3)]);
                Console.ResetColor();
                Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
                Console.ReadKey();
                return true;
            }
        }
        private static int showInfoEntities(Hero p, Enemy e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Вы: {p.Name}\nHP: {p.HP}\nМана: {p.Mana}");
            Console.SetCursorPosition(100, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Враг: " + e.Name);
            Console.SetCursorPosition(100, 1);
            Console.WriteLine("HP: " + e.HP);
            Console.SetCursorPosition(100, 2);
            Console.WriteLine("Мана: " + e.Mana);
            Console.ResetColor();
            String[] text = new string[]
            {
                "1 - Нанести удар",
                "2 - Открыть сумку",
                "3 - Применить заклинание",
                "4 - Попытаться сбежать (шанс смерти!)"
            };
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Выберите действие: ");
            for (int i = Console.WindowHeight / 2, j = 0; i < (Console.WindowHeight / 2) + 4; i++, j++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, i);
                Console.WriteLine(text[j]);
            }
            int choose;
            while (true)
            {
                bool check = Int32.TryParse(Console.ReadLine(), out choose);

                if (!check)
                    Console.WriteLine("Неверные данные! Введите еще раз.");
                else
                {
                    if (choose == 1 || choose == 2 || choose == 3 || choose == 4)
                        break;
                    else
                        Console.WriteLine("Неверное значение, введите еще раз!");
                }
            }
            return choose;

        }
        private static int showInfoBoss(Hero p, Enemy e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You: {p.Name}\nHP: {p.HP}");
            Console.SetCursorPosition(100, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Boss: " + e.Name);
            Console.SetCursorPosition(100, 1);
            Console.WriteLine("HP: " + e.HP);
            Console.ResetColor();
            String[] text = new string[]
            {
                "1 - Нанести удар",
                "2 - Открыть сумку",
                "3 - Применить заклинание"
            };
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            Console.WriteLine("Выберите действие: ");
            for (int i = Console.WindowHeight / 2, j = 0; j <2; i++, j++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, i);
                Console.WriteLine(text[j]);
            }
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
            return choose;

        }
        private static int HitEnemy(Hero p, Enemy e)
        {
            int damage = p.Hit(e);
            if (damage == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Вы промахнулись!");
                Console.ResetColor();
            }
            else if (damage == 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("Существо повержено!");
                Console.ResetColor();
                e.State = States.Dead;
                
                
                    Stats.allStats[BuildPlayer.PIndex].enemiesKilled++;
                
                return 0;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;

                e.HP -= damage;
                Console.WriteLine("Вы нанесли существу " + damage + " HP!");
                Console.ResetColor();
            }
            return 0;
        }
        public static void OpenInventory(Hero p, Enemy e)
        {
            p.inventory.ShowInventory();
            int index;
            while (true)
            {
                bool check = Int32.TryParse(Console.ReadLine(), out index);

                if (!check)
                    Console.WriteLine("Неверные данные! Введите еще раз.");
                else
                {
                    if (index != 6)
                    {
                        if ((index >= 1 && index <= 5))
                            break;
                        else
                            Console.WriteLine("Неверное значение, введите еще раз!");
                    }
                    else
                        break;
                }
            }
            if (index == 6)
                return;
            Stats.allStats[BuildPlayer.PIndex].itemsUsed++;
            p.inventory.UseItem(index - 1, p, e, true);
        }
        public static void OpenSpells(Hero p, Enemy e)
        {
            p.spellsInventory.ShowInventory();
            int index;
            while (true)
            {
                bool check = Int32.TryParse(Console.ReadLine(), out index);

                if (!check)
                    Console.WriteLine("Неверные данные! Введите еще раз.");
                else
                {
                    if (index != 3)
                    {
                        if ((index == 1 ||index==2))
                            break;
                        else
                            Console.WriteLine("Неверное значение, введите еще раз!");
                    }
                    else
                        break;
                }
            }
            if (index == 3)
                return;
            Stats.allStats[BuildPlayer.PIndex].spellsUsed++;
            p.spellsInventory.UseSpell(index - 1, p, e, true);
        }
        private static int AI(Hero p, Enemy e)
        {
            if (e.Step == 0)
            {
                Random rand = new Random();
                int enemyDecision = rand.Next(1, 101);
                if (enemyDecision < 60)
                    enemyDecision = 1;
                else
                {
                    enemyDecision = rand.Next(1, 101);
                    if (enemyDecision < 50)
                        enemyDecision = 2;
                    else
                        enemyDecision = 3;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                switch (enemyDecision)
                {
                    case 1:
                        int damage = e.Hit(p);
                        if (damage == 0)
                        {
                            Console.WriteLine("Существо промахнулось!");
                        }
                        else if (damage == 1)
                        {
                            Console.WriteLine("Вы мертвы!");
                            p.State = States.Dead;
                            Console.ResetColor();
                            return 1;
                        }
                        else
                        {
                            p.HP -= damage;
                            Console.WriteLine("Существо нанесло вам " + damage + " HP");
                        }
                        break;
                    case 2:
                        e.inventory.UseItem(rand.Next(0, 5), p, e, false);
                        break;
                    case 3:
                        e.SpellsInventory.UseSpell(rand.Next(0, 2), p, e, false);

                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Существо оглушено еще на {e.Step} ход(-ов)!");
                Console.ResetColor();
            }
            return 0;
        }
        private static int Fight(Hero p, Enemy e)
        {
            Random rand = new Random();
            int choose;
            while (p.State != States.Dead || e.State != States.Dead|| p.HP==0)
            {
                Console.Clear();
                choose = showInfoEntities(p, e);
                if (p.Step == 0)
                {
                    switch (choose)
                    {
                        case 1:
                            HitEnemy(p, e);
                            break;
                        case 2:
                            OpenInventory(p, e);
                            break;
                        case 3:
                            OpenSpells(p, e);
                            break;
                        case 4:
                            if (EscapeFromFight())
                                return 0;
                            else
                            {
                                p.State = States.Dead;
                                return 1;
                            }
                            break;
                        default:
                            break;

                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine($"Вы оглушены еще на {p.Step} ход(-ов)!");
                    Console.ResetColor();
                }
                if (AI(p, e) == 1)
                    return 1;
                p.Step--;
                e.Step--;
                Console.ResetColor();
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
                Console.ReadKey();
            }
            return 0;

        }
        private static int kingFight(Hero p, WraithKing e)
        {
            Random rand = new Random();
            int choose;
            while (p.State != States.Dead || e.State != States.Dead)
            {
                Console.Clear();
                choose = showInfoBoss(p, e);
                switch (choose)
                {
                    case 1:
                        if (HitEnemy(p, e)==1)
                            return 1;
                        break;
                    case 2:
                        OpenInventory(p, e);
                        break;
                    case 3:
                        OpenSpells(p, e);
                        break;
                    default:
                        break;

                }
                int enemyDecision = rand.Next(1, 101);
                if (enemyDecision < 60)
                    enemyDecision = 1;
                else
                {
                    enemyDecision = rand.Next(1, 40);
                    if (enemyDecision < 20)
                        enemyDecision = 2;
                    else
                        enemyDecision = 3;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                switch (enemyDecision)
                {
                    case 1:
                        int damage = e.Hit(p);
                        if (damage == 0)
                        {
                            Console.WriteLine("Король промахнулся!");
                        }
                        else if (damage == 1)
                        {
                            Console.WriteLine("Вы мертвы!");
                            p.State = States.Dead;
                            Console.ResetColor();
                            return 1;
                        }
                        else
                        {
                            p.HP -= damage;
                            Console.WriteLine("Король нанес вам " + damage + " HP");
                        }
                        break;
                    case 2:
                        e.skelet(p);
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
                Console.ResetColor();
                Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
                Console.ReadKey();
            }
            return 0;

        }
        public static int fightWithEnemy(Hero p, Enemy e)
        {
            String[] text = new string[]
            {
                "Идя по коридору вы услышали странный звук сверху. Когда вы посмотрели вверх, то увидели существо похожее на паука прямо над вами!",
                "Вы услышали крик из под пола. Нагнувшись, чтобы прислушаться, пол чуть не провалился прямо под вами и обезображенное существо выпрыгнуло оттуда!",
                "Войдя в странный зал и , на удивление освещенный зал, вы увидели много статуй, похожих на Ктулху, неожиданно одна из статуй ожила!",
                "Идя мимо щели в полу, что-то схватило вас за ногу и утащило вниз. Вы приземлились на кучу человеческий останков и перед вами встало чудище в виде оборотня!",
                "Вы завернули за угол и увидели старый труп. Нагнувшись, чтобы его обыскать он резко схватил вас за руку!"
            };
            Random rand = new Random();
            int action = rand.Next(0, 5);
            Console.WriteLine(text[action]);
            int left = Console.WindowWidth, top = Console.WindowHeight;
            Console.SetCursorPosition(left / 2, top / 2);
            Console.WriteLine("Что будете делать?");
            Console.SetCursorPosition(left / 2, (top / 2) + 1);
            Console.WriteLine("1- драться\t2- бежать (шанс смерти!)");
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
                if (Fight(p, e) == 1)
                    return 1;
                else
                    return 0;
            }
            else
            {
                if (EscapeFromFight())
                    return 0;
                else
                {
                    p.State = States.Dead;
                    return 1;
                }
            }
            Console.Clear();
            return 0;
        }
        public static int FindChest(Hero p)
        {
            String[] text = new string[]
            {
                "Идя по длинному коридору вы увидели как в конце него стоит большой, но странный сундук, будете смотреть что там?",
                "Обыскивая очередной уголок темного подземелья вы заметили небольшой сундучок в углу, вроде бы ничего не предвещает опасности, но стоит ли его открывать?",
                "Вы вошли в тяжелую дверь и увидели, что это похоже на маленькую заброшенную библиотеку. Немного пошаря по книжным полкам вы услышали тихий шорох за одной из них, отодвинув полку вы увидели массивный деревянный сундук. Открыть?",
                "Идя по подземелью вы увидели дырку в полу прикрытую деревянными досками, отломав доски, за ними оказалась небольшая яма с позолоченным сундуком, спрыгнуть и открыть его?"
            };
            Random rand = new Random();
            int action = rand.Next(0, 4);
            Console.WriteLine(text[action]);
            int left = Console.WindowWidth, top = Console.WindowHeight;
            Console.SetCursorPosition(left / 2, top / 2);
            Console.WriteLine("1- открыть\t2- не трогать");
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
                int chance = rand.Next(0, 101);
                if (chance < 20)
                {
                    Console.WriteLine("Это оказался мимик, придется сражаться!");
                    Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
                    Console.ReadKey();
                    if(Fight(p, new Enemy("Мимик"))==1)
                    {
                        return 1;
                    }
                }
                else
                {
                    String[] items = new string[] { "Бутылка", "Святой фрукт", "Парализующая каска", "Книга знаний", "Отравленный стилет", "Трава исцеления" };
                    string find = items[rand.Next(0, 6)];
                    Console.WriteLine("Повезло, это был обычный сундук и вы нашли " + find);
                    p.inventory.AddItem(find, p);
                    Stats.allStats[BuildPlayer.PIndex].chestsLooted++;
                    Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                return 0;
            }
            Console.Clear();
            return 0;
        }
        public static void SafeZone(Hero p, Shop shop)
        {
            String[] text = new string[]
            {
                "Идя по коридору, вы увидели таинстевенную дверь из-за которой исходил приглушенный свет. Вы прислушались, за ней играла успокаивающая музыка. Войдя в нее вы увидели торговца и место для ночлега.",
                "Недалеко вы услышали спокойную музыку, обошедший комнату несколько раз вы не нашли двери. Облокотившись на стену передохнуть вы провалились в комнату для ночлега. Нежданчик!",
                "Идя по подземелью на вас, неожиданно, свалился странный камень, подняв его вас ослепила вспышка и вы оказались в комнате с ночлегом."
            };

            Random rand = new Random();
            Console.WriteLine(text[rand.Next(0, 3)]);
            int left = Console.WindowWidth, top = Console.WindowHeight, choose;
            Console.SetCursorPosition(left / 2, top / 2);
            Console.WriteLine("Что будете делать?");
            Console.SetCursorPosition(left / 2, (top / 2) + 1);
            Console.WriteLine("1 - торговать\t2 - спать");
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
                shop.AddItem(p);
                p.HP = p.MaxHP;
                p.Mana = p.MaxMana;
                Console.WriteLine("Наконец вы смогли передохнуть в спокойном и безопасном месте под спокойную музыку. HP и мана восстановлены.");
            }
            else
            {
                p.HP = p.MaxHP;
                p.Mana = p.MaxMana;
                Console.WriteLine("Наконец вы смогли передохнуть в спокойном и безопасном месте под спокойную музыку. HP и мана восстановлены.");
            }
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();
            return;
        }


        public static int Trap(Hero h)
        {
            String[] text = new string[]
                {
                    "Впереди вы увидели два прохода, они полностью одинаковые.",
                    "Идя по подземелью вы увидели две лестницы, одна была завивистая и очень странная, вторая обычная прямая.",
                    "Исследую очередной коридор вы увидели две двери, слева была массивная и пошарпанная, вторая обычных размеров и деревянная."
                };

            Random rand = new Random();
            Console.WriteLine(text[rand.Next(0, 3)]);
            int left = Console.WindowWidth, top = Console.WindowHeight, choose;
            Console.SetCursorPosition(left / 2, top / 2);
            Console.WriteLine("Куда идти?");
            Console.SetCursorPosition(left / 2, (top / 2) + 1);
            Console.WriteLine("1 - налево\t2 - направо");
            int action=rand.Next(1,101);
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
                if(action>=1&&action<=50)
                {
                    int hp = rand.Next(1, 21);
                    h.HP -=hp;
                    Console.WriteLine($"Вы попали в ловушку! Вам нанесено {hp} HP.");
                }
                else
                {
                    if(Events.fightWithEnemy(h,new Enemy())==1)
                    {
                        return 1;
                    }
                }
            }
            else
            {
                if (action >= 1 && action <= 50)
                    if(Events.FindChest(h)==1)
                    {
                        return 1;
                    }
                else
                {
                    int hp = rand.Next(1, 31);
                    h.HP -= hp;
                    Console.WriteLine($"Вы попали в ловушку! Вам нанесено {hp} HP.");
                }
            }
            Console.WriteLine("Нажмите любую кнопку, чтобы продолжить...");
            Console.ReadKey();
            Console.Clear();
            return 0;
        }
        public static int fightWithKing(Hero p)
        {
            Console.WriteLine("Вы вошли в большой тронный зал. На пьедестале стоял трон, а на нем сидел скелет в броне короля. В руке он держал массивный меч. Вы поднялись к трону и осмотрели его. Только вы прикоснулись к мечу, как глаза скелета засветились и он резко ударом ноги скинул вас вниз. Серьезный противник, но выхода нет, придется драться!");
            if(kingFight(p,new WraithKing())==1)
            {
                return 1;
            }
            return 0;
        }
    }
}

