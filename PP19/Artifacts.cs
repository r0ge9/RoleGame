using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    [Serializable]
    abstract class Artifacts
    {
        public void Bottle(Hero p,Enemy e,bool used)
        {
            Random rand = new Random();
            if (used)
            {
                int healed = rand.Next(10, 31);
                p.HP += healed;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы сделали глоток из бутылки и почувствовали прилив сил! Восстановлено "+healed+" HP");
                Console.ResetColor();
            }
            else
            {
                int healed = rand.Next(10, 21);
                e.HP += healed;
                e.Mana += healed;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Существо быстро высосало кровь из рядом лежащего трупа! Восстановлено " + healed + " HP и "+healed+" маны");
                Console.ResetColor();
            }
            return;
        }

        public void BookOfKnowledge(Hero p,Enemy e,bool used)
        {
            if (used)
            {
                p.EXP += 100;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Вы прочитали старую книгу с названием 'КПиЯП для чайников'. Получено {100} EXP");
                Console.ResetColor();
            }
            else
            {
                e.MissChance -= 10;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Существо резко начало вести себя по другому. Нежданчик! Шанс промаха уменьшен на 10%");
                Console.ResetColor();
            }
            return;
        }

        public void HolyFruit(Hero p,Enemy e,bool used)
        {
            if (used)
            {
                p.HP = p.MaxHP;
                p.State = States.Normal;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы съели божественный фрукт и как будто заново родились! HP восстановлено, сняты все побочные эффекты.");
                Console.ResetColor();

            }
            else
            {
                e.HP = e.MaxHP;
                e.State = States.Normal;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Существо выпило своей крови! HP восстановлено, сняты все побочные эффекты.");
                Console.ResetColor();
            }
            return;
        }

        public void StiletOfPoison(Hero p,Enemy e,bool used)
        {
            Random rand = new Random();
            if (used)
            {
                int damage = rand.Next(10, 31);
                e.HP -= damage;
                e.State = States.Poisoned;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Вы метнули отравленный нож прямо в печень существу! Нож в печень - никто не вечен! Нанесено {damage} урона, наложен эффект отравления.");
                Console.ResetColor();
            }
            else
            {
                int damage = rand.Next(10, 21);
                p.HP -= damage;
                p.State = States.Poisoned;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Существо плюнуло в вас чем то едким! Фу, а смердит то как! Нанесено {damage} урона, наложен эффект отравления.");
                Console.ResetColor();
            }
            return;
        }

        public void HealingVerb(Hero p,Enemy e,bool used)
        {
            Random rand = new Random();
            if (used)
            {
                int healed = rand.Next(5, 11);
                p.HP += healed;
                p.State = States.Normal;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Не зря сделали чай из этих листьев. Чай восстановил {healed} HP и снял все отрицательные эффекты.");
                Console.ResetColor();
            }
            else
            {
                int healed = rand.Next(5, 11);
                e.HP += healed;
                e.State = States.Normal;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Существо озарилось ярким светом, что ослепило вас. Как только вы открыли глаза оно выглядело, как новое!. Свет восстановил {healed} HP и снял все отрицательные эффекты.");
                Console.ResetColor();
            }
            return;
        }

        public void ParalyzingCask(Hero p,Enemy e, bool used)
        {
            if (used)
            {
                e.State = States.Paralyzed;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Вы метнули прогнившую чугунную каску прямо в подобие лица существу. Все таки не зря этот хлам собирал! Каска парализовало существо на 5 ходов!");
                Console.ResetColor();
            }
            else
            {
                p.State = States.Paralyzed;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Существо неожиданно для вас подняло огромную глыбу и метнула в вас. Вас завалило и потребуется какое-то время, чтобы выбраться. Вас парализовало на 3 хода!");
                Console.ResetColor();
            }
            return;
        }
    }
}
