using Microsoft.VisualStudio.TestTools.UnitTesting;
using bkw.auto.interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bkw.auto.biz.tests
{
    [TestClass]
    public class UnitTest2
    {
        IVehicleOptionsProvider badOptionsProvider = new MismatchedOptionsProvider();

 
        [TestMethod]
        public void TestBuildInvalidEnconomyCar()
        {
            IVehicle subjUnderTest = EconomyCar.BuildCar("Ford Pinto", badOptionsProvider);


            DoValidationStuff(subjUnderTest);
        }

        [TestMethod]
        public void TestBuildInvalidSportsCar()
        {
            IVehicle subjUnderTest = SportsCar.BuildCar("Ford Mustang", badOptionsProvider);

            DoValidationStuff(subjUnderTest);
        }


        [TestMethod]
        public void TestBuildInvalidTruckCommercial()
        {
            IVehicle subjUnderTest = TruckCommercial.BuildCar("Ford Econoline", badOptionsProvider);

            DoValidationStuff(subjUnderTest);
        }

        [TestMethod]
        public void TestBuildInvalidTruckPickup()
        {
            IVehicle subjUnderTest = TruckPickup.BuildCar("Ford F-150", badOptionsProvider);

            DoValidationStuff(subjUnderTest);
        }

        private static void DoValidationStuff(IVehicle subjUnderTest)
        {
            if (subjUnderTest is IValidatableObject)
            {
                var vehicleValiationResults = ((IValidatableObject)subjUnderTest).Validate(null);

                foreach (var err in vehicleValiationResults)
                {
                    Console.WriteLine(err.ErrorMessage);
                }
                Assert.IsTrue(vehicleValiationResults.Any(), "Expected some validation errors");
            }
            else
            {
                Assert.Fail("Expected vehicle to be IValidatable");
            }
        }
    }
}