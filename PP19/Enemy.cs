using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    enum States
    {
        Normal,
        Weakened,
        IsIll,
        Poisoned,
        Paralyzed,
        Dead
    }
    class Enemy
    {
        public Enemy(String name)
        {
            Random rand = new Random();
            Name = name;
            MaxHP = rand.Next(100, 300);
            HP = MaxHP;
            MaxMana = rand.Next(100, 300);
            Mana = MaxMana;
            
        }
        public Enemy()
        {
            String[] names = { "Паук", "Гуль", "Кровосос", "Утопец", "Подземный червь", "Оборотень", "Зомби" };
            Random rand = new Random();
            Name = names[rand.Next(0,7)];
            MaxHP = rand.Next(100, 300);
            HP = MaxHP;
            MaxMana = rand.Next(100, 300);
            Mana = MaxMana;

        }
        public Inventory inventory = new Inventory(false);
        public SpellsInventory SpellsInventory = new SpellsInventory(false);
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
        protected int maxHP;

        public int MaxHP
        {
            get { return maxHP; }
            set 
            { 
                if (value < 0) 
                    throw new Exception("Error of enemy max hp.");
                else 
                    maxHP = value; 
            }
        }

        protected int missChance = 30;

        public int MissChance
        {
            get { return missChance; }
            set 
            {
                if (value < 0)
                    missChance = 0 ;
                else
                    missChance = value;
            }
        }

        protected int hp;

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

        protected int maxMana;

        public int MaxMana
        {
            get { return maxMana; }
            set 
            {
                if (value < 0)
                    maxMana = 0;
                else
                    maxMana = value;
            }
        }

        protected int mana;

        public int Mana
        {
            get { return mana; }
            set
            {
                if (value < 0)
                    mana = 0;
                else
                    mana = value;
            }
        }

        protected String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        

        protected States state;

        public States State
        {
            get { return state; }
            set { state = value; }
        }

        public int Hit(Hero p)
        {
            Random rand = new Random();
            if (rand.Next(2, 101) < missChance)
                return 0;
            else if (p.HP > 100)
            {
                return rand.Next(20, 51);
            }
            else if (p.HP > 50 && p.HP < 100)
                return rand.Next(10, 21);
            else if (p.HP < 50 && p.HP > 20)
                return rand.Next(2, 11);
            else
            {
                int random = rand.Next(2, 11);
                if (p.HP - random < 0)
                {
                    p.HP = 0;
                    return 1;
                }
                else
                    return random;
            }
        }

    }
}
