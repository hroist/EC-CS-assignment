using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraphicApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicApp.MVVM.Models;

namespace GraphicApp.MVVM.ViewModels
{
    public partial class AddContactViewModel : ObservableObject
    {

        private readonly FileService fileService;

        public AddContactViewModel()
        {
            fileService = new FileService();    
        }

        [ObservableProperty]
        private string pageTitle = "Skapa en ny kontakt";

        [ObservableProperty]
        private string firstName = string.Empty;

        [ObservableProperty]
        private string lastName = string.Empty;

        [ObservableProperty]
        private string email = string.Empty;

        [ObservableProperty]
        private string phoneNumber = string.Empty;

        [ObservableProperty]
        private string streetName = string.Empty;

        [ObservableProperty]
        private string postalCode = string.Empty;

        [ObservableProperty]
        private string city = string.Empty;

        [ObservableProperty]
        private string addedTextMessage = string.Empty;

        [RelayCommand]
        private void Add()
        {
            ContactService.Add(new Models.ContactModel { FirstName = FirstName , LastName = LastName , Email = Email , PhoneNumber = PhoneNumber, StreetName = StreetName , PostalCode = PostalCode , City = City });
            FirstName = String.Empty;
            LastName = String.Empty;
            Email = String.Empty;
            PhoneNumber = String.Empty;
            StreetName = String.Empty;
            PostalCode= String.Empty;
            City = String.Empty;
            AddedTextMessage= "Kontakten har lagts till";
        }



    }
}
