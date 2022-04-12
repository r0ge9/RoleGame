using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    [Serializable]
    class Spells
    {
        protected void ShowNoMana()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Не хватает маны для использования!");
            Console.ResetColor();
            return;
        }
        protected void ShowProcastMessage(ConsoleColor color,String text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
            return;
        }
        protected void MeteorHammer(Hero p, Enemy e, bool used)
        {
            if(used)
            {
                if(p.checkManaCost(30))
                {
                    ShowProcastMessage(ConsoleColor.Green, "Начав читать свиток, над головой существа начало появляться странная голубая пыль сразу после прочтения обрушился град метеоритов, охренеть! Существо оглушено на 3 хода!");
                    e.Step = 3;
                }
                else
                {
                    ShowNoMana();
                }
            }
            else
            {
                ShowProcastMessage(ConsoleColor.Red, "Существо взяла булыжник и швырнула его в вас с огромной силой! Вы оглушены на 2 хода!");
                p.Step=2;
            }
            return;
        }
        protected void EMP(Hero p, Enemy e, bool used)
        {
            if (used)
            {
                if (p.checkManaCost(20))
                {
                    e.Mana = 0;
                    ShowProcastMessage(ConsoleColor.Green, "Вы прочитали свиток под названием 'Против волшебников' и существо затряслось, но тут же пришло в норму. Вы выжгли всю ману у существа!");
                }
                else
                    ShowNoMana();
            }
            else
            {
                p.Mana = 0;
                ShowProcastMessage(ConsoleColor.Red, "Неожиданно существо начало что то шептать и вы ощутили магическую слабость. Вот чертила! Вам выжгли всю ману.");
            }
            return;
        }

        protected void Cataclysm(Hero p,Enemy e,bool used)
        {
            if(used)
            {
                if (p.checkManaCost(60))
                {
                    e.State = States.Dead;
                    ShowProcastMessage(ConsoleColor.Green, "Ваш дед называл это заклинание для пианистов, вы чуть запнувшись прочли все и в миг начался катаклизм и так же быстро закончился. Оно испепилило существо в секунду!");
                }
                else
                    ShowNoMana();
            }
            
            return;
        }

        protected void Teleport(Hero p,Enemy e,bool used)
        {
            if (used)
            {
                if (p.checkManaCost(90))
                {
                    ShowProcastMessage(ConsoleColor.Green, "В конце свитка было написано 'закройте глаза', после их открытия вы оказались в неизвестном месте, но за то без существа, повезло!");
                    e.State = States.Dead;
                }
                else
                    ShowNoMana();
            }
            
        }

        protected void FullHeal(Hero p,Enemy e,bool used)
        {
            if(used)
            {
                if (p.checkManaCost(40))
                {
                    p.HP = p.MaxHP;
                    ShowProcastMessage(ConsoleColor.Green, "В названий говорится, что лечит даже оторванные конечности, вы читаете и понимаете, что это правда! Здоровье полностью восстановлено.");
                }
                else
                {
                    ShowNoMana();
                }
            }
            else
            {
                e.HP = e.MaxHP;
                ShowProcastMessage(ConsoleColor.Red, "Неожиданно существо затряслось и восстановило все повреждения. Черт все насмарку! Здоровье полностью восстановлено.");
            }
            return;
        }
    }
}
