using Microsoft.VisualStudio.TestTools.UnitTesting;
using Places.Models;
using System.Collections.Generic;
using System;

namespace Places.Tests
{
    [TestClass]
    public class CategoryTests : IDisposable
    {

        public void Dispose()
        {
            Category.ClearAll();
        }
        [TestMethod]
        public void CategoryConstructor_CreatesInstanceOfCategory_Category()
        {
            Category newCategory = new Category("test category");
            Assert.AreEqual(typeof(Category), newCategory.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            //Arrange
            string name = "Test Category";
            Category newCategory = new Category(name);

            //Act
            string result = newCategory.Name;

            //Assert
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void GetId_ReturnsCategoryId_Int()
        {
            //Arrange
            string name = "Test Category";
            Category newCategory = new Category(name);

            //Act
            int result = newCategory.Id;

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllCategoryObjects_CategoryList()
        {
            //Arrange
            string name01 = "Work";
            string name02 = "School";
            Category newCategory1 = new Category(name01);
            Category newCategory2 = new Category(name02);
            List<Category> newList = new List<Category> { newCategory1, newCategory2 };

            //Act
            List<Category> result = Category.GetAll();

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectCategory_Category()
        {
            //Arrange
            string name01 = "Work";
            string name02 = "School";
            Category newCategory1 = new Category(name01);
            Category newCategory2 = new Category(name02);

            //Act
            Category result = Category.Find(2);

            //Assert
            Assert.AreEqual(newCategory2, result);
        }

        [TestMethod]
        public void AddDestination_AssociatesDestinationWithCategory_DestinationList()
        {
            //Arrange
            string cityName = "Amsterdam";
            string description = "Walk the dog.";
            Destination newDestination = new Destination(cityName, description);
            List<Destination> newList = new List<Destination> { newDestination };
            string name = "Work";
            Category newCategory = new Category(name);
            newCategory.AddDestination(newDestination);

            //Act
            List<Destination> result = newCategory.Destinations;

            //Assert
            CollectionAssert.AreEqual(newList, result);
        }
    }
}