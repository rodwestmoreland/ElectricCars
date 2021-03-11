using _02_ProjectGreen_Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _02_ProjectGreen_Console
{
    class UI
    {
        private static Car_Repo _carRepo = new Car_Repo();
        public static List<Car> _carList = new List<Car>();
        
        public void Run()
        {
            SeedThis();
            MenuOps.MenuSelections();
        }

        public static void GetCars()
        {
            List<Car> _list = _carRepo.GetCars();
            
            Console.WriteLine(String.Format("{0,-4} {1,-10} {2,-14} {3,-37} {4,-12} {5,-14} {6,-8}", "VID","Engine", "Make", "Model", "Collision", "Comprehensive", "Injury" ));
            foreach (var car in _list)
            {
                
                Console.WriteLine(String.Format("{0,-4} {1,-10} {2,-14} {3,-30} | {4,12} {5,12} {6,12}"
                                ,car.Id, car.Propulsion, car.Make, car.Model
                                ,car.Collision.ToString("P0"), car.Comprehensive.ToString("P0"), car.PersonalInjury.ToString("P0")
                                
                                ));
            }
        }

        public void AddCar()
        {
            Car newItem = new Car();
            List<Car> _list = _carRepo.GetCars();
            ushort carNum = 0;
            bool numberFound = false;
            bool numberCheck = true;
            do
            {
                
                Console.Write("Enter an ID Number > ");
                
                string verifyInput = Console.ReadLine();
                if (ushort.TryParse(verifyInput, out carNum))
                {
                    foreach (var item in _list)
                    {
                        if (item.Id == carNum)
                        { numberFound = true; }

                    }//foreach
                    if (numberFound)
                    {
                        int maxID = _list.Max(x => x.Id);
                        Console.WriteLine($"pick another number. FYI: The highest number in the inventory is {maxID}");
                        numberFound = false;
                    }
                    else { numberFound = false; numberCheck = false; }

                }
                else { Console.WriteLine("Error: Invalid input. Try again."); numberCheck = true; }



            } while (numberCheck);

            AddCarDetails(newItem, carNum);
            _carRepo.AddCar(newItem);
            Console.WriteLine();
        }

        public void UpdateCar()
        {
            Car newItem = new Car();
            ushort getId = FindCarByID();

            AddCarDetails(newItem, getId);
            _carRepo.UpdateCar(getId, newItem);
            Console.WriteLine();
        }

        private static ushort FindCarByID()
        {
            Console.Write("Enter car ID number : >");
            string checkId = (Console.ReadLine());
            if (ushort.TryParse(checkId, out ushort getId))
            { 
                var carToUpdate = _carRepo.GetCarById(getId);
                if (carToUpdate == null)
                { Console.WriteLine("ERROR: Check the ID number and try again.\n\n"); MenuOps.MenuSelections(); }

                Console.WriteLine($"\nSelected vehicle {carToUpdate.Make} {carToUpdate.Model}\n");
            }else 
            { Console.WriteLine("ERROR: Check the ID number and try again.\n\n"); MenuOps.MenuSelections(); }

            return getId;
        }

        public void DeleteCar()
        {
            ushort getId = FindCarByID();
            Console.Write("Is this the vehicle you wish to remove? > ");
            string response = Console.ReadLine();
            if (response == "y")
            { _carRepo.DeleteCar(getId); Console.WriteLine("\nVehicle Removed"); } 
            else { Console.WriteLine("Invalid Response. Return to the menu");  }

        }

        private static void AddCarDetails(Car newItem, ushort carNum)
        {
            Console.Write("Enter a car make > ");
            string carMake = (Console.ReadLine());

            Console.Write("Enter a model > ");
            string carModel = (Console.ReadLine());

            Console.Write("Enter engine type > ");
            string carEngine = (Console.ReadLine());
            
            bool numberCheck = true;
            double carCollision=0.0;
            do { 
            Console.Write("Enter reported collision percentage in decimal format (e.g. 42% = .42) > ");
          
            string verifyInput = (Console.ReadLine());
            if (double.TryParse(verifyInput, out double userInput))
            {
                carCollision = userInput ;
                numberCheck = false;
            }
            else
            {
                Console.WriteLine("ERROR: Needs to be in decial format (e.g. 0.10).\n\n");
                numberCheck = true;
            }

        } while (numberCheck);

            
            //Console.Write("Enter reported personal injury percentage > ");
            //double carInjury = Convert.ToDouble(Console.ReadLine());
            
            double carComprehensive = 0.0;
            do
            {
                Console.Write("Enter reported comprehensive percentage in decimal format (e.g. 42% = .42) > ");

                string verifyInput = (Console.ReadLine());
                if (double.TryParse(verifyInput, out double userInput))
                {
                    carComprehensive = userInput;
                    numberCheck = false;
                }
                else
                {
                    Console.WriteLine("ERROR: Needs to be in decial format (e.g. 0.10).\n\n");
                    numberCheck = true;
                }

            } while (numberCheck);


            double carInjury = 0.0;
            do
            {
                Console.Write("Enter reported personal injury percentage in decimal format (e.g. 42% = .42) > ");

                string verifyInput = (Console.ReadLine());
                if (double.TryParse(verifyInput, out double userInput))
                {
                    carInjury = userInput;
                    numberCheck = false;
                }
                else
                {
                    Console.WriteLine("ERROR: Needs to be in decial format (e.g. 0.10).\n\n");
                    numberCheck = true;
                }

            } while (numberCheck);

            Console.Clear();

            Console.WriteLine();
            Console.WriteLine($"ID # {carNum}:  {carMake}  {carModel}\n " +
                $"Collision: {carCollision}\t Comprehensive: {carComprehensive}\t Personal Injury: {carInjury}\n");
            Console.Write("Confirm: Is this information correct?\n (y/n) > ");

            string response = (Console.ReadLine().ToLower());
            if (response == "y")
            {
                newItem.Id = carNum;
                newItem.Make = carMake;
                newItem.Model = carModel;
                newItem.Propulsion = carEngine;
                newItem.Collision = carCollision;
                newItem.Comprehensive = carComprehensive;
                newItem.PersonalInjury = carInjury;
            }
            else { Console.WriteLine("Invalid response. Changes not saved. Please try again.\n\n" ); MenuOps.MenuSelections(); }


        }//AddCarDetails()

        public void SeedThis()
        {
            var car1 = new Car(5, "Kia", "Rio", "thermal", .1, .1, .1);
            _carRepo.AddCar(car1);

            var path = @"passengerCars.csv";
            var seedFile = File.ReadAllLines(path);
            
            var content = seedFile.Skip(1).Select(c => c.Split(','))
                                .Select(c => new Car()
                                {
                                    Id = Convert.ToUInt16(c[0]),
                                    Make = c[1],
                                    Model = c[2],
                                    Propulsion = c[3],
                                    Collision = Convert.ToDouble(c[4]),
                                    Comprehensive = Convert.ToDouble(c[5]),
                                    PersonalInjury = Convert.ToDouble(c[6]),
                                }).ToList();

            
        _carRepo.AddCars(content); //add the list of cars from file
            
        }

    }
}
