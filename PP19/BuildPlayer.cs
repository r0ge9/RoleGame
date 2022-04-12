using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PP19
{
    class BuildPlayer
    {
        private delegate void _menuBuildPlayer(ref Hero player);
        private static bool ActiveBuildMenuPlayer = true;
        private static String[] _BuildMenuPlayer = new String[] { "{Empty player}", "{Empty player}", "{Empty player}" };
        public static Hero[] savePlayers = new Hero[3] { new Hero(), new Hero(), new Hero() };
        public static int PIndex = 0;
        public static bool FirstOpen = false;
        private static int CompletePoint = 0;
        public static bool YesOrNo(String YourChooseStr)
        {
            Console.Clear();
            String[] Race = new String[3] { " ", "[Yes]", "[No]" };
            bool[] YesNot = new bool[2] { true, false };
            bool Com = false;
            char[] MyChar = { '=', '<' };
            var top = Console.CursorTop;
            while (true)
            {
                Console.Write(YourChooseStr + "\n");
                for (int i = 1; i < Race.Length; ++i)
                    Console.WriteLine(Race[i]);
                ConsoleKeyInfo keyN = Console.ReadKey();
                Console.SetCursorPosition(10, top);
                if (keyN.Key == ConsoleKey.UpArrow)
                {
                    Console.CursorVisible = false;
                    top -= 1;
                    if (top > 0)
                    {
                        Console.SetCursorPosition(10, top);
                        Console.CursorTop = top;
                    }
                    else
                        top = 1;
                    if (Console.CursorTop > 0)
                    {
                        if (Console.CursorTop == 1)
                            Race[Console.CursorTop] = Race[Console.CursorTop].TrimEnd(MyChar);
                        Race[Console.CursorTop] += "<==";
                        Race[Console.CursorTop + 1] = Race[Console.CursorTop + 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 1;
                }
                if (keyN.Key == ConsoleKey.DownArrow)
                {

                    Console.CursorVisible = false;
                    Console.SetCursorPosition(10, Console.CursorTop + 1);
                    if (Console.CursorTop < 3)
                    {
                        Race[Console.CursorTop] += "<==";
                        Race[Console.CursorTop - 1] = Race[Console.CursorTop - 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 3;
                }
                if (keyN.Key == ConsoleKey.Enter)
                {
                    Com = YesNot[Console.CursorTop - 1];
                    break;
                }
                Console.Clear();
            }
            return Com;
        }
        private static void BuildNamePlayer(ref Hero player)
        {
            CompletePoint++;
            Console.Clear();
            Console.Write("Name your Hero:");
            string str = Console.ReadLine();
            player.Name = str;
        }
        private static void BuildRacePlayer(ref Hero player)
        {
            CompletePoint++;
            Console.Clear();
            Console.WriteLine("Please select race player\n");
            Console.WriteLine("|Press any key|");
            Console.ReadKey();
            Console.Clear();
            String[] Race = new String[4] { "[Human]", "[Gnom]", "[Elf]", "[Goblin]" };
            String[] _Race = new String[4] { "Human", "Gnom", "Elf", "Goblin" };
            char[] MyChar = { '=', '<' };
            var top = Console.CursorTop;
            while (true)
            {
                for (int i = 0; i < Race.Length; ++i)
                    Console.WriteLine(Race[i]);
                ConsoleKeyInfo keyN = Console.ReadKey();
                Console.SetCursorPosition(10, top);
                if (keyN.Key == ConsoleKey.UpArrow)
                {
                    Console.CursorVisible = false;
                    top -= 1;
                    if (top > -1)
                    {
                        Console.SetCursorPosition(10, top);
                        Console.CursorTop = top;
                    }
                    else
                        top = 0;
                    if (Console.CursorTop > -1)
                    {
                        if (Console.CursorTop == 0)
                            Race[Console.CursorTop] = Race[Console.CursorTop].TrimEnd(MyChar);
                        Race[Console.CursorTop] += "<==";
                        Race[Console.CursorTop + 1] = Race[Console.CursorTop + 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 0;
                }
                if (keyN.Key == ConsoleKey.DownArrow)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(10, Console.CursorTop + 1);
                    if (Console.CursorTop < 4)
                    {
                        Race[Console.CursorTop] += "<==";
                        Race[Console.CursorTop - 1] = Race[Console.CursorTop - 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 4;
                }
                if (keyN.Key == ConsoleKey.Enter)
                {
                    player.Race = _Race[Console.CursorTop];
                    break;
                }
                Console.Clear();
            }
        }
        private static void BuildGenderPlayer(ref Hero player)
        {
            CompletePoint++;
            Console.Clear();
            Console.WriteLine("Please select gender player\n");
            Console.WriteLine("|Press any key|");
            Console.ReadKey();
            Console.Clear();
            String[] Gender = new String[2] { "[Man]", "[Woman]" };
            String[] _Gender = new String[2] { "Man", "Woman" };
            char[] MyChar = { '=', '<' };
            var top = Console.CursorTop;
            while (true)
            {
                for (int i = 0; i < Gender.Length; ++i)
                    Console.WriteLine(Gender[i]);
                ConsoleKeyInfo keyN = Console.ReadKey();
                Console.SetCursorPosition(10, top);
                if (keyN.Key == ConsoleKey.UpArrow)
                {
                    Console.CursorVisible = false;
                    top -= 1;
                    if (top > -1)
                    {
                        Console.SetCursorPosition(10, top);
                        Console.CursorTop = top;
                    }
                    else
                        top = 0;
                    if (Console.CursorTop > -1)
                    {
                        if (Console.CursorTop == 0)
                            Gender[Console.CursorTop] = Gender[Console.CursorTop].TrimEnd(MyChar);
                        Gender[Console.CursorTop] += "<==";
                        Gender[Console.CursorTop + 1] = Gender[Console.CursorTop + 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 0;
                }
                if (keyN.Key == ConsoleKey.DownArrow)
                {

                    Console.CursorVisible = false;
                    Console.SetCursorPosition(10, Console.CursorTop + 1);
                    if (Console.CursorTop < 2)
                    {
                        Gender[Console.CursorTop] += "<==";
                        Gender[Console.CursorTop - 1] = Gender[Console.CursorTop - 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 2;
                }
                if (keyN.Key == ConsoleKey.Enter)
                {
                    player.Sex = _Gender[Console.CursorTop];
                    break;
                }
                Console.Clear();
            }
        }
        private static void BuildAgePlayer(ref Hero player)
        {
            CompletePoint++;
            Console.Clear();
            int age = 0;
            Console.Write("Input Age your Hero:");
            while (!int.TryParse(Console.ReadLine(), out age))
                Console.WriteLine("Не правильный ввод данных!");
            player.Age = age;
        }
        private static bool TempCreatePersonMenu(ref Hero player)
        {
            Console.Clear();
            _menuBuildPlayer[] _Menus = new _menuBuildPlayer[4] { BuildNamePlayer, BuildRacePlayer, BuildGenderPlayer, BuildAgePlayer };
            String[] BuildPlayer = new String[4] { "[Input Name Hero]", "[Select Race Hero]", "[Select Gender Hero]", "[Input Age Hero]" };
            var top = Console.CursorTop;
            char[] MyChar = { '=', '<' };
            while (true)
            {
                for (int i = 0; i < BuildPlayer.Length; ++i)
                    Console.WriteLine(BuildPlayer[i]);
                ConsoleKeyInfo keyN = Console.ReadKey();
                Console.SetCursorPosition(10, top);
                if (keyN.Key == ConsoleKey.UpArrow)
                {
                    Console.CursorVisible = false;
                    top -= 1;
                    if (top > -1)
                    {
                        Console.SetCursorPosition(10, top);
                        Console.CursorTop = top;
                    }
                    else
                        top = 0;
                    if (Console.CursorTop > -1)
                    {
                        if (Console.CursorTop == 0)
                            BuildPlayer[Console.CursorTop] = BuildPlayer[Console.CursorTop].TrimEnd(MyChar);
                        BuildPlayer[Console.CursorTop] += "<==";
                        BuildPlayer[Console.CursorTop + 1] = BuildPlayer[Console.CursorTop + 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 0;
                }
                if (keyN.Key == ConsoleKey.DownArrow)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(10, Console.CursorTop + 1);
                    if (Console.CursorTop < 4)
                    {
                        BuildPlayer[Console.CursorTop] += "<==";
                        BuildPlayer[Console.CursorTop - 1] = BuildPlayer[Console.CursorTop - 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 4;
                }
                if (keyN.Key == ConsoleKey.Enter)
                {
                    BuildPlayer[Console.CursorTop] = BuildPlayer[Console.CursorTop].Trim(MyChar);
                    BuildPlayer[Console.CursorTop] += " Complete!";
                    int tempcurs = Console.CursorTop;
                    _Menus[Console.CursorTop](ref player);
                    Console.SetCursorPosition(0, tempcurs);
                    _Menus[Console.CursorTop] = null;
                    if (CompletePoint == 4)
                        return true;
                }
                if (keyN.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    return false;
                }
                Console.Clear();
            }
        }
        private static bool SelectOrRedaction()
        {
            Console.Clear();
            String[] Race = new String[3] { " ", "[Redaction this Hero]", "[Select this Hero]" };
            bool[] YesNot = new bool[2] { false, true };
            bool Com = false;
            char[] MyChar = { '=', '<' };
            var top = Console.CursorTop;
            while (true)
            {
                Console.Write("Redaction or Select this Hero?\n");
                for (int i = 1; i < Race.Length; ++i)
                    Console.WriteLine(Race[i]);
                ConsoleKeyInfo keyN = Console.ReadKey();

                Console.SetCursorPosition(10, top);
                if (keyN.Key == ConsoleKey.UpArrow)
                {
                    Console.CursorVisible = false;
                    top -= 1;
                    if (top > 0)
                    {
                        Console.SetCursorPosition(10, top);
                        Console.CursorTop = top;
                    }
                    else
                        top = 1;
                    if (Console.CursorTop > 0)
                    {
                        if (Console.CursorTop == 1)
                            Race[Console.CursorTop] = Race[Console.CursorTop].TrimEnd(MyChar);
                        Race[Console.CursorTop] += "<==";
                        Race[Console.CursorTop + 1] = Race[Console.CursorTop + 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 1;
                }
                if (keyN.Key == ConsoleKey.DownArrow)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(10, Console.CursorTop + 1);
                    if (Console.CursorTop < 3)
                    {
                        Race[Console.CursorTop] += "<==";
                        Race[Console.CursorTop - 1] = Race[Console.CursorTop - 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 3;
                }
                if (keyN.Key == ConsoleKey.Enter)
                {
                    Com = YesNot[Console.CursorTop - 1];
                    break;
                }
                Console.Clear();
            }
            return Com;
        }
        public static (Hero, Hero[], int) BuildMenuPlayer()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            Console.Clear();
            bool temp = false;
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            String str = "[========================================================]";
            Console.Write(str[0]);
            for (int i = 1; i < str.Length - 1; i++)
            {
                Thread.Sleep(25);
                Console.Write(str[i]);
            }
            Console.Write(str[str.Length - 1]);
            Thread.Sleep(200);
            Console.SetCursorPosition((Console.WindowWidth / 2) + 17, (Console.WindowHeight / 2) + 2);
            Console.Write("Please press any key");
            Console.ReadKey();
            Console.Clear();
            var top = Console.CursorTop;
            Hero returnPlayer = null;
            Hero[] deserilizePeople = null;
            using (FileStream fs = new FileStream("Hero.dat", FileMode.OpenOrCreate))
            {
                try
                {
                    deserilizePeople = (Hero[])formatter.Deserialize(fs);
                }
                catch (Exception e)
                {

                }
                
                if (deserilizePeople != null)
                {

                    for (int i = 0; i < _BuildMenuPlayer.Length; ++i)
                    {
                        if (deserilizePeople[i].Name != " ")
                            _BuildMenuPlayer[i] = "[ " + deserilizePeople[i].Name + " ]";
                        else
                        {
                            _BuildMenuPlayer[i] = "{Empty player}";
                        }
                    }
                }
            }
            while (ActiveBuildMenuPlayer)
            {
                Console.Clear();
                for (int i = 0; i < _BuildMenuPlayer.Length; ++i)
                {
                    Console.WriteLine(_BuildMenuPlayer[i]);
                }
                ConsoleKeyInfo keyN = Console.ReadKey();
                char[] MyChar = { '=', '<' };
                Console.SetCursorPosition(10, top);
                if (keyN.Key == ConsoleKey.UpArrow)
                {
                    Console.CursorVisible = false;
                    top -= 1;
                    if (top > -1)
                    {
                        Console.SetCursorPosition(10, top);
                        Console.CursorTop = top;
                    }
                    else
                        top = 0;
                    if (Console.CursorTop > -1)
                    {
                        if (Console.CursorTop == 0)
                            _BuildMenuPlayer[Console.CursorTop] = _BuildMenuPlayer[Console.CursorTop].TrimEnd(MyChar);
                        _BuildMenuPlayer[Console.CursorTop] += "<==";
                        _BuildMenuPlayer[Console.CursorTop + 1] = _BuildMenuPlayer[Console.CursorTop + 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 0;
                }
                if (keyN.Key == ConsoleKey.DownArrow)
                {
                    Console.CursorVisible = false;
                    Console.SetCursorPosition(10, Console.CursorTop + 1);
                    if (Console.CursorTop < 3)
                    {
                        _BuildMenuPlayer[Console.CursorTop] += "<==";
                        _BuildMenuPlayer[Console.CursorTop - 1] = _BuildMenuPlayer[Console.CursorTop - 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 3;
                }
                if (keyN.Key == ConsoleKey.Enter)
                {
                    char[] MyChar2 = new char[4] { '[', ']', '{', '}' };
                    Menu.NewPlayer(false);
                    int tempCurs;
                    if (_BuildMenuPlayer[Console.CursorTop] != "{Empty player}<==")
                    {
                        tempCurs = Console.CursorTop;
                        if (SelectOrRedaction() == true)
                        {
                            using (FileStream fs = new FileStream("Hero.dat", FileMode.OpenOrCreate))
                            {
                                deserilizePeople = (Hero[])formatter.Deserialize(fs);
                                returnPlayer = deserilizePeople[tempCurs];
                            }
                            FirstOpen = false;
                            Console.SetCursorPosition(10, tempCurs);
                            _BuildMenuPlayer[Console.CursorTop] = "[ " + deserilizePeople[Console.CursorTop].Name + " ]";
                            for (int i = 0; i < _BuildMenuPlayer.Length; i++)
                            {
                                if (i != Console.CursorTop)
                                {
                                    _BuildMenuPlayer[i] = _BuildMenuPlayer[i].Trim(MyChar2);
                                    _BuildMenuPlayer[i] = "{" + _BuildMenuPlayer[i] + "}";
                                }
                            }
                            PIndex = tempCurs;
                            return (returnPlayer, deserilizePeople, PIndex);
                        }
                        else
                        {
                            tempCurs = Console.CursorTop;
                            temp = TempCreatePersonMenu(ref savePlayers[Console.CursorTop]);
                            CompletePoint = 0;
                            Console.SetCursorPosition(10, tempCurs);
                            if (temp == true)
                            {
                                _BuildMenuPlayer[Console.CursorTop] = "[ " + deserilizePeople[Console.CursorTop].Name + " ]";
                                for (int i = 0; i < _BuildMenuPlayer.Length; i++)
                                {
                                    if (i != Console.CursorTop)
                                    {
                                        _BuildMenuPlayer[i] = _BuildMenuPlayer[i].Trim(MyChar2);
                                        _BuildMenuPlayer[i] = "{" + _BuildMenuPlayer[i] + "}";
                                    }
                                }
                                using (FileStream fs = new FileStream("Hero.dat", FileMode.OpenOrCreate))
                                {
                                    formatter.Serialize(fs, savePlayers);
                                }
                                FirstOpen = false;
                                using (FileStream fs = new FileStream("Hero.dat", FileMode.OpenOrCreate))
                                { 
                                    deserilizePeople = (Hero[])formatter.Deserialize(fs);
                                    returnPlayer = deserilizePeople[tempCurs];
                                }
                                PIndex = tempCurs;
                                return (returnPlayer, deserilizePeople, PIndex);
                            }

                        }
                    }
                    else
                    {
                        tempCurs = Console.CursorTop;

                        temp = TempCreatePersonMenu(ref savePlayers[Console.CursorTop]);
                        CompletePoint = 0;
                        Console.SetCursorPosition(10, tempCurs);
                        deserilizePeople = savePlayers;
                        if (temp == true)
                        {
                            _BuildMenuPlayer[Console.CursorTop] = "[ " + deserilizePeople[Console.CursorTop].Name + " ]";
                            for (int i = 0; i < _BuildMenuPlayer.Length; i++)
                            {
                                if (i != Console.CursorTop)
                                {
                                    _BuildMenuPlayer[i] = _BuildMenuPlayer[i].Trim(MyChar2);
                                    _BuildMenuPlayer[i] = "{" + _BuildMenuPlayer[i] + "}";
                                }
                            }
                            using (FileStream fs = new FileStream("Hero.dat", FileMode.OpenOrCreate))
                            {
                                formatter.Serialize(fs, savePlayers);
                            }
                            FirstOpen = false;
                        }
                        PIndex = tempCurs;
                        returnPlayer = deserilizePeople[tempCurs];
                        return (returnPlayer, deserilizePeople, PIndex);
                    }
                }
                if (keyN.Key == ConsoleKey.Backspace)
                {
                    int tempCurs = Console.CursorTop;
                    Console.Clear();
                    bool tmp = YesOrNo("Delete hero?");
                    if (tmp)
                        _BuildMenuPlayer[tempCurs] = "{Empty player}";
                }
                if (keyN.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Menu._Menu();
                }
                Console.Clear();
            }
            return (returnPlayer, deserilizePeople, PIndex);
        }
    }
}
