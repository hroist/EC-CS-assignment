using GraphicApp.MVVM.Models;
using GraphicApp.MVVM.ViewModels;
using GraphicApp.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicApp.Tests
{
    public class AddContactsViewModel_Tests
    {
        private readonly AddContactViewModel viewModel;
        readonly ContactModel contact = new() { FirstName = "Test", LastName = "Testson", Email = "test@mail.com", PhoneNumber = "0701457889", StreetName = "Testvägen 1", PostalCode = "12345", City = "Teststaden" };
        

        public AddContactsViewModel_Tests()
        {
            viewModel = new AddContactViewModel();
            ContactService.filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\adressbok_test.json";
        }


        [Fact]
        public void Should_Add_Contact_To_ObservableCollection()
        {
            // Act
            ContactService.Add(contact);
            var contactList = ContactService.Contacts();

            // Assert
            contactList.Should().Contain(contact);
        }

    }
}
