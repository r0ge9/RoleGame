using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    [Serializable]
    class Stats
    {
        public int enemiesKilled=0;
        public int bossesKilled=0;
        public int itemsUsed=0;
        public int spellsUsed=0;
        public int chestsLooted=0;
        public static Stats[] allStats = { new Stats(), new Stats(), new Stats() };
        private static BinaryFormatter formatter = new BinaryFormatter();

        public static void LoadStats()
        {
            using (FileStream fs = new FileStream("Stats.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    allStats = (Stats[])formatter.Deserialize(fs);
                }
                catch (Exception e)
                {

                }
            }
        }
        public static void SaveStats()
        {
            using (FileStream fs = new FileStream("Stats.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, allStats);
            }
        }
        public static void TextStats()
        {
            using (StreamWriter writer = new StreamWriter("Stats.txt"))
            {
                for (int i = 0; i < allStats.Length; i++)
                {
                    writer.WriteLine($"{i + 1} player");
                    writer.WriteLine(allStats[i].ToString());
                }
            }
        }
        public override string ToString()
        {
            return $"Enemies killed: {enemiesKilled}\nBosses killed: {bossesKilled}\nItems used: {itemsUsed}\nSpells used: {itemsUsed}\nChests looted: {chestsLooted}";
        }
    }
}
