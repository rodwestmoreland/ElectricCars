using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using _02_ProjectGreen_Repo;
using System.Collections.Generic;

namespace _02_ProjectGreen_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        
            Car_Repo _carRepo = new Car_Repo();
            List<Car> _carList = new List<Car>();

            public List<Car> SeedThis()
            {
            var car1 = new Car(1, "Kia", "Rio", "thermal", .1, .1, .1);
            //_carRepo.AddCar(car1);

            var car2 = new Car(2, "Test", "TestModel", "hybrid", .1, .1, .1);
            //_carRepo.AddCar(car2);

                _carList.Add(car1);
                _carList.Add(car2);

                return _carList;
            }

            [TestMethod]
            public void CreatingItems()
            {
                SeedThis();
                foreach (var item in _carList)
                {
                    _carRepo.AddCar(item);
                }

                int itemCheck = _carRepo.GetCars().Count;

            Assert.AreEqual(2, itemCheck);
            Car item3 = new Car(3, "TestAdd", "TestModelADD", "electric", .1, .1, .1);
            _carRepo.AddCar(item3);
            //bool isAdded = _carRepo.AddCar(item3);
            Assert.AreEqual(2, itemCheck);
            Console.WriteLine(itemCheck);

            itemCheck = _carRepo.GetCars().Count;
            //  Assert.IsTrue(isAdded);
            Assert.AreEqual(3, itemCheck);

            }

            [TestMethod]
            public void ReadingItems()
            {
                CreatingItems();

                int i = 0;
                var _list = _carRepo.GetCars();

                foreach (var item in _list)
                {
                    i++;
                }

                Assert.AreEqual(3, i);
            }

            [TestMethod]  
            public void UpdatingItems()
            {
            CreatingItems();
            var newItem = _carRepo.GetCarById(1);
            newItem.Id = 1;
            newItem.Make = "UpdatedMake";
            newItem.Model = "UpdatedModel";
            newItem.Propulsion = "";
            newItem.Collision = .1;
            newItem.Comprehensive = .1;
            newItem.PersonalInjury = .1;

            
            _carRepo.UpdateCar(1, newItem);

            var checkItem = _carRepo.GetCarById(1);

            Assert.AreEqual("UpdatedMake", checkItem.Make);
            }

            [TestMethod]
            public void DeletingItems()
            {
                CreatingItems();
                ushort getId = _carList[1].Id;

                Car checkObj = _carRepo.GetCarById(getId);

                Assert.AreEqual(2, getId);

            //bool isDeleted = _carRepo.DeleteCar(getId);

            //Assert.IsTrue(isDeleted);
            _carRepo.DeleteCar(getId);

            checkObj = _carRepo.GetCarById(getId);

                Assert.IsNull(checkObj);
            }

     }//class
}
