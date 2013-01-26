﻿using System;

namespace dewitcher
{
    public static class Bootscreen
    {
        public enum Effect : byte
        { SlideFromLeft, SlideFromRight, SlideFromTop, SlideFromBottom, Typewriter, Matrix }
        public static void Show(string OSname, Effect efx, ConsoleColor color, int ticks = 1000000)
        {
            switch (efx)
            {
                case Effect.SlideFromLeft:

                    for (int i = 0; i < ((Console.WindowWidth / 2) - (OSname.Length / 2)); i++)
                    {
                        Console.Clear();
                        Console.CursorLeft = i;
                        string fill = "";
                        for (int x = 0; x < i; x++) fill += " ";
                        Console.Write(fill);
                        Console.Write(OSname, color, false, true);
                        RTC.Sleep.SleepTicks(ticks);
                    } break;

                case Effect.SlideFromRight:

                    for (int i = (Console.WindowWidth - OSname.Length);
                        i > ((Console.WindowWidth / 2) - (OSname.Length / 2)); i--)
                    {
                        Console.Clear();
                        Console.CursorLeft = i;
                        Console.Write(OSname, color, false, true);
                        RTC.Sleep.SleepTicks(ticks);
                    } break;

                case Effect.SlideFromTop:

                    for (int i = 0; i < (Console.WindowHeight / 2); i++)
                    {
                        Console.Clear();
                        Console.CursorTop = i;
                        Console.WriteLine(OSname, color, true, false);
                        RTC.Sleep.SleepTicks(ticks);
                    } break;

                case Effect.SlideFromBottom:

                    for (int i = (Console.WindowHeight - 1); i > (Console.WindowHeight / 2); i--)
                    {
                        Console.Clear();
                        Console.CursorTop = i;
                        Console.WriteLine(OSname, color, true, false);
                        RTC.Sleep.SleepTicks(ticks);
                    } break;

                case Effect.Typewriter:

                    Console.CursorLeft = ((Console.WindowWidth / 2) - (OSname.Length / 2));
                    foreach (char chr in OSname)
                    {
                        Console.Write(chr.ToString(), color, false, true);
                        RTC.Sleep.SleepTicks(ticks);
                    } break;

                case Effect.Matrix:

                    int sec1 = RTC.Now.Second;
                    int sec2 = sec1;
                    do { sec2 = RTC.Now.Second; } while (sec1 == sec2);
                    int sec3;
                    if (sec2 <= 56) sec3 = sec2 + 3;
                    else if (sec2 == 57) sec3 = 1;
                    else if (sec2 == 58) sec3 = 2;
                    else if (sec2 == 59) sec3 = 3;
                    else sec3 = 3;
                    int tmr = 0;
                    int tmrx = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        for (int ih = 0; ih < Console.WindowHeight; ih++)
                        {
                            for (int iw = 0; iw < Console.WindowWidth; iw++)
                            {
                                if (tmr == 11) tmr = 0;
                                if (tmrx == 4) tmrx = 0;
                                tmr++;
                                if (tmr == 0) Console.Write("#", ConsoleColor.Magenta);
                                else if (tmrx == 3) Console.Write("*", ConsoleColor.Green);
                                else if (tmr == 2) { Console.Write(";", ConsoleColor.Red); ++tmrx; }
                                else if (tmrx == 1) Console.Write("+", ConsoleColor.Yellow);
                                else if (tmr == 4) { Console.Write("~", ConsoleColor.Blue); ++tmrx; }
                                else if (tmrx == 2) Console.Write("&", ConsoleColor.Cyan);
                                Console.Write(OSname, ConsoleColor.White, true, true);
                            }
                        }
                    } break;
            }
        }
    }
}