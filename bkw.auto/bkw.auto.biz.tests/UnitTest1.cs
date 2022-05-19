using Microsoft.VisualStudio.TestTools.UnitTesting;
using bkw.auto.interfaces;
using System;
using System.Linq;
using System.Collections.Generic;

namespace bkw.auto.biz.tests
{
    [TestClass]
    public class UnitTest1
    {
        IVehicleOptionsProvider vehicleOptionsProvider = new bkw.auto.provider.CompiledVehicleOptionsProvider();

        [TestMethod]
        public void TestLoadingOptions()
        {
            //get options from provider
            var economyCarOptions = vehicleOptionsProvider.GetVehicleOptions(VehicleKind.EconomyCar);
            Assert.IsNotNull(economyCarOptions);
            Assert.AreEqual(11, economyCarOptions.Count());

            //Linq sanity test
            var dto = economyCarOptions.Where(opt => opt is drivetrains.DriveTrainOption);
            Assert.IsNotNull(dto);
            Assert.AreEqual(4, dto.Count(), "Expected 4 drive train options from linq query");

            //load options test
            var DriveTrain = new bkw.auto.biz.drivetrains.StandardDriveTrain();
            DriveTrain.LoadOptions(dto);

            Assert.IsNotNull(DriveTrain.AvailableOptions);
            Assert.AreEqual(4, DriveTrain.AvailableOptions.Count(), "Expected 4 drive train options after Load operation");

        }

        [TestMethod]
        public void TestBuildValidEnconomyCar()
        {
            IVehicle subjUnderTest = EconomyCar.BuildCar("Ford Pinto", vehicleOptionsProvider);

            Console.WriteLine($"{subjUnderTest}");

            Console.WriteLine($"{subjUnderTest.ToLongString()}");

            Assert.AreEqual(4, subjUnderTest.DriveTrain.AvailableOptions.Count());
            Assert.AreEqual(4, subjUnderTest.Exterior.AvailableOptions.Count());
            Assert.AreEqual(3, subjUnderTest.Interior.AvailableOptions.Count(), "Should have loaded options for Interior");
        }

        [TestMethod]
        public void TestBuildValidSportsCar()
        {
            IVehicle subjUnderTest = SportsCar.BuildCar("Ford Mustang", vehicleOptionsProvider);

            Console.WriteLine($"{subjUnderTest}");
            Console.WriteLine($"{subjUnderTest.ToLongString()}");

            Assert.AreEqual(4, subjUnderTest.DriveTrain.AvailableOptions.Count(),"Should have loaded options for DriveTrain");
            Assert.AreEqual(4, subjUnderTest.Exterior.AvailableOptions.Count(), "Should have loaded options for Exterior");
            Assert.AreEqual(4, subjUnderTest.Interior.AvailableOptions.Count(), "Should have loaded options for Interior");
        }

        [TestMethod]
        public void TestBuildValidTruckCommercial()
        {
            IVehicle subjUnderTest = TruckCommercial.BuildCar("Ford Econoline", vehicleOptionsProvider);

            Console.WriteLine($"{subjUnderTest}");
            Console.WriteLine($"{subjUnderTest.ToLongString()}");

            Assert.AreEqual(2, subjUnderTest.DriveTrain.AvailableOptions.Count(),"Should have loaded options for DriveTrain");
            Assert.AreEqual(5, subjUnderTest.Exterior.AvailableOptions.Count(), "Should have loaded options for Exterior");
            Assert.AreEqual(4, subjUnderTest.Interior.AvailableOptions.Count(), "Should have loaded options for Interior");
        }

        [TestMethod]
        public void TestBuildValidTruckPickup()
        {
            IVehicle subjUnderTest = TruckPickup.BuildCar("Ford F-150", vehicleOptionsProvider);

            Console.WriteLine($"{subjUnderTest}");
            Console.WriteLine($"{subjUnderTest.ToLongString()}");

            Assert.AreEqual(5, subjUnderTest.DriveTrain.AvailableOptions.Count(),"Should have loaded options for DriveTrain");
            Assert.AreEqual(5, subjUnderTest.Exterior.AvailableOptions.Count(), "Should have loaded options for Exterior");
            Assert.AreEqual(4, subjUnderTest.Interior.AvailableOptions.Count(), "Should have loaded options for Interior");
        }
    }
}