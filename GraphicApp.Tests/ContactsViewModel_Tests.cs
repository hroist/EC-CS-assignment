using GraphicApp.MVVM.Models;
using GraphicApp.MVVM.ViewModels;
using GraphicApp.Services;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicApp.Tests
{
    public class ContactsViewModel_Tests
    {
        private readonly ContactsViewModel viewModel;
        readonly ContactModel contact = new() { FirstName = "Test", LastName = "Testson", Email = "test@mail.com", PhoneNumber = "0701457889", StreetName = "Testvägen 1", PostalCode = "12345", City = "Teststaden" };

        public ContactsViewModel_Tests()
        {
            viewModel = new ContactsViewModel();
        }

        [Fact]
        public void Should_Get_An_ObservableCollection_With_Contacts()
        {
            // Act
            var result = ContactService.Contacts();

            // Assert
            viewModel.Contacts.Should().BeOfType<ObservableCollection<ContactModel>>();

        }


        [Fact]
        public void Should_Delete_Contact_From_ObservableCollection()
        {
            // Act
            viewModel.Contacts.Add(contact);
            viewModel.Contacts.Remove(contact);

            // Assert
            viewModel.Contacts.Should().NotContain(contact);
        }
    }
}
