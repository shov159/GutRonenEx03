using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    internal class Program
    {
        public static void Main()
        {
            Garage garage = new Garage();
            Factory factory = new Factory();
            ConsoleUserInterface ui = new ConsoleUserInterface();

            ui. runMenu(garage, factory);
        }

       
    }
}