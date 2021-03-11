using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProjectGreen_Console
{
    public class MenuOps
    {

        public static void MenuSelections()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.WriteLine("Electric and Hybrid insurance statistics 2017-2019 \nSelect option 1 - 5:\n\n" +
                        "1. View all vehicles\n" +
                        "2. Add a vehicle to list\n" +
                        "3. Update a vehicle\n" +
                        "4. Delete an vehicle by ID number \n" +
                        "5. Exit");

                string menuSelect = (Console.ReadLine());
                MenuSelectionCheck(menuSelect);
            }// \while


        }//MenuSelections()


        public static void MenuProcessing(byte selection)
        {
            var ui = new UI();

            Console.Clear();

            switch (selection)
            {
                case 1:
                    UI.GetCars();
                    ClickToCont();
                    break;
                case 2:
                    ui.AddCar();
                    ClickToCont();
                    break;
                case 3:
                    ui.UpdateCar();
                    ClickToCont();
                    break;
                case 4:
                    ui.DeleteCar();
                    ClickToCont();
                    break;
            }

        }//MenuProcessing()

        private static void MenuSelectionCheck(string menuSelect)
        {
            if (Byte.TryParse(menuSelect, out byte num))
            {
                if (num == 5)
                { Environment.Exit(0); }
                else if (num > 0 && num < 5)
                { MenuProcessing(num); }
                else
                { InvalidSelection(); }
            }
            else
            { InvalidSelection(); }
        }

        public static void InvalidSelection()
        {
            Console.Clear();
            Console.WriteLine("\nPlease enter a number 1 - 5\n");
        }

        private static void ClickToCont()
        {
            Console.WriteLine("\n\n\nPress any key to continue");
            Console.ReadKey();
            Console.Clear();
        }


    }//class
}
