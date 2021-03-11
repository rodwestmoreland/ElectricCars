using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProjectGreen_Repo
{
    public class Car_Repo
    {
        private List<Car> _carRepo = new List<Car>();

        public List<Car> GetCars()
        { return _carRepo; }

        public void AddCar(Car car)
        { _carRepo.Add(car); }

        public void AddCars(List<Car> cars)
        {
            foreach (var car in cars)
            {  _carRepo.Add(car); }
        }

        public void UpdateCar(ushort id, Car newCarInfo)
        {
            var currentCar = GetCarById(id);

            currentCar.Make =           newCarInfo.Make;
            currentCar.Model =          newCarInfo.Model;
            currentCar.Propulsion =     newCarInfo.Propulsion;
            currentCar.Collision =      newCarInfo.Collision;
            currentCar.Comprehensive =  newCarInfo.Comprehensive;
            currentCar.PersonalInjury = newCarInfo.PersonalInjury;

        }

        public void DeleteCar(ushort id)
        {
            _carRepo.Remove(GetCarById(id));
        }

        public Car GetCarById(ushort id)
        {
            return _carRepo.SingleOrDefault(x => x.Id == id);
        }


        public List<Car> SeedThis()
        {
            var path = @"passengerCars.csv";
            var seedFile = File.ReadAllLines(path);
            return seedFile.Skip(1).Select(c => c.Split(','))
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

        }

    }
}
