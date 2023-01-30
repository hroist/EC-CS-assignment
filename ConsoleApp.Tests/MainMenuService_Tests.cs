using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{ 
    [TestClass]
    public class MainMenuService_Tests
    {

        [TestMethod]
        public void Should_Add_Contacts_To_List()
        {
            // Arrange
            MainMenuService mainMenuService = new MainMenuService();
            Contact contact = new Contact() { FirstName = "Test", LastName = "Testson", Email = "test@mail.com", PhoneNumber = "0701457889", StreetName = "Testvägen 1", PostalCode = "12345", City = "Teststaden" };
            List<IContact> contactsTestList = new List<IContact>();
            mainMenuService.contacts = contactsTestList;

            // Act
            mainMenuService.contacts.Add(contact);

            // Assert
            Assert.AreEqual(1, mainMenuService.contacts.Count);

        }
    }
}
