using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    class MagicHero : Hero
    {
        public SpellsInventory SpellsInventory = new SpellsInventory(true);

        private int maxMana;

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

        private int mana;

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

        public MagicHero(String name, String race, String sex) 
        {

        }

        public bool checkManaCost(double cost)
        {
            if (Mana < cost)
                return false;
            else
                return true;
        }

        public int calculateManaCost(int strenght,int manaCost)
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
