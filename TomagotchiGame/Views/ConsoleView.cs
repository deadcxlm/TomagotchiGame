﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomagotchiGame.Models;

namespace TomagotchiGame.Views
{
    public class ConsoleView : IView
    {
        public void DisplayClear()
        {
            Console.Clear();
        }

        public void DisplayActionMenu()
        {
            Console.WriteLine("\nAction menu:");
            Console.WriteLine("1. Feed");
            Console.WriteLine("2. Play");
            Console.WriteLine("3. Sleep");
            Console.WriteLine("4. Exit");
            Console.WriteLine("5. Save");
            Console.Write("Choose an action: ");
        }

        public void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayTomagotchiStatus(string name, int health, int hunger, int fatigue)
        {
            Console.WriteLine("───────────────────────────");
            Console.WriteLine($"Name:   {name}");
            Console.WriteLine($"Health: {health}");
            Console.WriteLine($"Hunger: {hunger}");
            Console.WriteLine($"Fatigue: {fatigue}");
            Console.WriteLine("───────────────────────────");
        }


        public string GetUserInput()
        {
            return Console.ReadLine()!;
        }

        public void DrawTomagotchi(TomagotchiStateEnum state)
        {
            switch (state)
            {
                case TomagotchiStateEnum.Happy:
                    Console.WriteLine("\t /\\_/\\\r\n\t( o.o )\r\n\t > ^ <");
                    break;
                case TomagotchiStateEnum.Sad:
                    Console.WriteLine("\t  /~~~\\\r\n\t / o o \\\r\n\t(   \"   )\r\n\t \\  -  /\r\n\t  \\___/");
                    break;
                case TomagotchiStateEnum.Dead:
                    Console.WriteLine("\t  ________\r\n\t /        \\\r\n\t|  R.I.P.  |\r\n\t \\________/");
                    break;
                case TomagotchiStateEnum.Sleep:
                    Console.WriteLine("\t  /\\_/\\  \r\n\t ( -.- ) \r\n\t  Zzzzz ");
                    break;
            }
        }
    }
}