using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class ThreadWork
    {
        public static void Dots()
        {
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write('.');
                    System.Threading.Thread.Sleep(1000);
                    if (i == 2)
                    {
                        Console.Write("\r   \r");
                        i = -1;
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
        }
            public static void Load()
        {
            while (true)
            {
                double contador2 = 0;
                int contador1 = 0;
                int start = 0;
                var originalposstart = Console.CursorLeft + 1;
                for (int i = 0; i < 25; i++)
                {
                    var originalpos = Console.CursorLeft;
                    if (contador1 != -1)
                    {
                        Console.Write('.');
                    }
                    Console.SetCursorPosition(start, Console.CursorTop + 1);
                    Console.Write('█');
                    start++;
                    Console.SetCursorPosition(10, Console.CursorTop);
                    contador2 = contador2 + 4;
                    Console.Write((contador2).ToString());
                    Console.SetCursorPosition(originalposstart + contador1, Console.CursorTop - 1);
                    contador1++;
                    System.Threading.Thread.Sleep(100);
                    if (i == 24)
                    {
                        System.Threading.Thread.Sleep(1000000);
                    }
                    if (contador1 == 3)
                    {
                        contador1 = -1;
                        Console.SetCursorPosition(originalposstart - 2, Console.CursorTop);
                        Console.Write("    ");
                        Console.SetCursorPosition(originalposstart - 2, Console.CursorTop);
                    }
                }
            }
        }
    }
}

