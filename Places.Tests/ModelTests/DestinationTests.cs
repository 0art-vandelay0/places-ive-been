using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Places.Models;
using System;

namespace Places.Tests
{
    [TestClass]
    public class DestinationTests : IDisposable
    {

        public void Dispose()
        {
            Destination.ClearAll();
        }

        [TestMethod]
        public void DestinationConstructor_CreatesInstanceOfDestination_Destination()
        {
            Destination newDestination = new Destination("Amsterdam", "test");
            Assert.AreEqual(typeof(Destination), newDestination.GetType());
        }

        [TestMethod]
        public void GetDescription_ReturnsDescription_String()
        {
            //Arrange
            string cityName = "Amsterdam";
            string description = "Walk the dog.";

            //Act
            Destination newDestination = new Destination(cityName, description);
            string result = newDestination.Description;

            //Assert
            Assert.AreEqual(description, result);
        }

        [TestMethod]
        public void SetDescription_SetDescription_String()
        {
            //Arrange
            string cityName = "Amsterdam";
            string description = "Walk the dog.";
            Destination newDestination = new Destination(cityName, description);

            //Act
            string updatedDescription = "Do the dishes";
            newDestination.Description = updatedDescription;
            string result = newDestination.Description;

            //Assert
            Assert.AreEqual(updatedDescription, result);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyList_DestinationList()
        {
            // Arrange
            List<Destination> newList = new List<Destination> { };

            // Act
            List<Destination> result = Destination.GetAll();

            // Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsDestinations_DestinationList()
        {
            //Arrange
            string cityName01 = "Amsterdam";
            string cityName02 = "New York";
            string description01 = "Walk the dog";
            string description02 = "Wash the dishes";
            Destination newDestination1 = new Destination(cityName01, description01);
            Destination newDestination2 = new Destination(cityName02, description02);
            List<Destination> newList = new List<Destination> { newDestination1, newDestination2 };

            //Act
            List<Destination> result = Destination.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetId_DestinationsInstantiateWithAnIdAndGetterReturns_Int()
        {
            //Arrange
            string cityName = "Amsterdam";
            string description = "Walk the dog.";
            Destination newDestination = new Destination(cityName, description);

            //Act
            int result = newDestination.Id;
            // int result = 0;

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectDestination_Destination()
        {
            //Arrange
            string cityName01 = "Amsterdam";
            string cityName02 = "New York";
            string description01 = "Walk the dog";
            string description02 = "Wash the dishes";
            Destination newDestination1 = new Destination(cityName01, description01);
            Destination newDestination2 = new Destination(cityName02, description02);

            //Act
            Destination result = Destination.Find(2);
            // Destination result = new Destination("Incorrect test Destination");

            //Assert
            Assert.AreEqual(newDestination2, result);
        }
    }
}