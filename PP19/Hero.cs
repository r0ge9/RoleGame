using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    [Serializable]
    class Hero : IComparable<Hero>
    {
        public Inventory inventory = new Inventory(true);
        protected String name=" ";

        public SpellsInventory spellsInventory = new SpellsInventory(true);

        public Hero()
        {
            inventory = new Inventory(true);
            spellsInventory = new SpellsInventory(true);
            MaxMana = 100;
            MaxHP = 100;
            Name = " ";
            Race = " ";
            Random rand = new Random();
            id = rand.Next(1, 1001);
            states = States.Normal;
            HP = MaxHP;
            Mana = MaxMana;
            Speaking = false;
            Moving = false;
            EXP = 1;
            Age = 1;
            Sex = " ";
        }
        private int step;

        public int Step
        {
            get { return step; }
            set 
            {
                if (value < 0)
                    step = 0;
                else
                    step = value;
            }
        }

        private int maxMana=100;

        public int MaxMana
        {
            get { return maxMana; }
            set
            {
                if (value < 0)
                    throw new Exception("Error of max mana value.");
                else
                    maxMana = value;
            }
        }

        private int mana=100;

        public int Mana
        {
            get { return mana; }
            set
            {
                if (value > 100 || value < 0)
                    throw new Exception("Error of mana value.");
                else
                    mana = value;
            }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        protected int id=0;



        private States states=States.Normal;

        public States State
        {
            get { return states; }
            set 
            {
                if (value == States.Dead)
                    Game.GameRunning = false;
                else
                    states = value;
            }
        }

        protected bool speaking=false;
                
        public bool Speaking
        {
            get { return speaking; }
            set { speaking = value; }
        }

        protected bool moving=false;

        public bool Moving
        {
            get { return moving; }
            set { moving = value; }
        }

        private String race=" ";

        public String Race
        {
            get { return race=" "; }
            set { race = value; }
        }


        private String sex=" ";

        public String Sex
        {
            get { return sex=" "; }
            set { sex= value; }
        }


        protected int age=1;

        public int Age
        {
            get { return age; }
            set 
            {
                if (value > 99 || value < 0)
                    Console.WriteLine("Wrong age, try again.");
                else
                    age = value;
            }
        }
        private int maxHP=100;

        public int MaxHP
        {
            get { return maxHP; }
            set 
            {
                if (value < 0)
                    throw new Exception("Error of max hp value.");
                else
                    maxHP = value;
            }
        }

        protected int hp=100;

        public int HP
        {
            get { return hp; }
            set 
            {
                if (value < 0)
                    hp = 0;
                else if (value > MaxHP)
                    hp = MaxHP;
                else
                    hp = value;
            }
        }

        protected double exp=1;

        public double EXP
        {
            get { return exp; }
            set 
            {
                if (value < 0)
                    throw new Exception("Error of exp value.");
                else
                    exp = value;
            }
        }

        public int CompareTo(Hero? a)
        {
            if (a is null)
                throw new ArgumentException("Object is null");
            else
                return EXP.CompareTo(a.EXP);
        }

        public int checkHpState()
        {
            int percentage= (100 / HP) * 100;
            if (percentage < 10)
                return 1;
            else if (percentage == 0)
                return 5;
            else
                return 0;
        }

        public override string ToString()
        {
            return $"ID={id}\nName={Name}\nAge={Age}\nRace={Race}\nSex={Sex}\nHP={HP}\nExperience={EXP}";
        }

        public int Hit(Enemy e)
        {
            Random rand = new Random();
            int random;
            if (EXP > 500)
                random = Convert.ToInt32(rand.Next(1, 40) * (EXP / 2) / 100);
            else
                random = rand.Next(2, 31);
            if (rand.Next(2, 101) < 30)
                return 0;
            else if (e.HP - random < 0)
                return 1;
            else
                return random;
        }

        public bool checkManaCost(double cost)
        {
            if (Mana < cost)
                return false;
            else
                return true;
        }

        public int calculateManaCost(int strenght, int manaCost)
        {
            int addition = (manaCost / 2) * strenght;
            if (checkManaCost(addition + manaCost))
                return addition + manaCost;
            else
                return 0;
        }

        public int healManaCost(int recover)
        {
            if (checkManaCost(recover * 2))
                return recover * 2;
            else
                return 0;
        }
    }
}
