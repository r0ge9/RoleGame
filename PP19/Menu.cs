using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP19
{
    class Menu
    {
        private delegate Hero _menu();
        private static String[] menu = new String[4] { "|New Game|", "|Continue|", "|Characters|", "|Exit|" };
        private static bool ActiveMenu = true;
        private static bool args = false;
        private static Hero hero = new Hero();
        public static bool NewPlayer(bool FirstLoggin)
        {
            if (FirstLoggin)
                return args;
            else
                return args = true;
        }
        private static Hero NewGame()
        {
            var next = BuildPlayer.BuildMenuPlayer();
            hero = next.Item1;
            Console.Clear();
            //Map.DisplayMap(hero, next.Item2, next.Item3);
            return null;
        }
        private static Hero Continue()
        {
            return null;
        }
        private static Hero Characters()
        {
            var next = BuildPlayer.BuildMenuPlayer();
            hero = next.Item1;
            Menu._Menu();
            return null;
        }
        private static Hero Exit()
        {
            return null;
        }
        public static Hero _Menu()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
            char[] MyChar = { '=', '<' };
            for (int i = 0; i < menu.Length; i++)
            {
                menu[i] = menu[i].TrimEnd(MyChar);
            }
            Console.ResetColor();
            Console.Clear();
            _menu[] _Menus = new _menu[4] { NewGame, Continue, Characters, Exit };
            var top = Console.CursorTop;
            while (ActiveMenu)
            {
                for (int i = 0; i < menu.Length; ++i)
                {
                    Console.WriteLine(menu[i]);
                    if (i != menu.Length - 1)
                        Console.Write("▬▬▬▬▬▬▬▬▬▬▬▬▬▬▬" + "\n");
                }
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
                            menu[Console.CursorTop] = menu[Console.CursorTop].TrimEnd(MyChar);
                        menu[Console.CursorTop] += "<==";
                        menu[Console.CursorTop + 1] = menu[Console.CursorTop + 1].TrimEnd(MyChar);
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
                        menu[Console.CursorTop] += "<==";
                        menu[Console.CursorTop - 1] = menu[Console.CursorTop - 1].TrimEnd(MyChar);
                        top = Console.CursorTop;
                    }
                    else
                        Console.CursorTop = 4;
                }
                if (keyN.Key == ConsoleKey.Enter)
                {
                    var hero= _Menus[Console.CursorTop]();
                    ActiveMenu = false;
                }
                Console.Clear();
            }
            return hero;
        }
    }
}
