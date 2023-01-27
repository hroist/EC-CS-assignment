using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Mvvm.Native;
using GraphicApp.MVVM.Models;
using GraphicApp.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GraphicApp.MVVM.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {

        public ContactsViewModel()
        {
            contacts = ContactService.Contacts();
        }

        [ObservableProperty]
        private string pageTitle = "Kontakter";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedIsNotNull), nameof(Contacts))]
        private ContactModel selectedContact = null!;

        [ObservableProperty]
        private bool selectedIsNotNull = false;

        [ObservableProperty]
        private bool showUpdateForm = false;

        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string phoneNumber;
        
        [ObservableProperty]
        private string streetName;

        [ObservableProperty]
        private string postalCode;

        [ObservableProperty]
        private string city;

        [ObservableProperty]
        private string updatedSuccess = string.Empty;

        [RelayCommand]
        private void Update()
        {
            SelectedContact.FirstName = FirstName;
            SelectedContact.LastName = LastName;
            SelectedContact.Email = Email;
            SelectedContact.PhoneNumber = PhoneNumber;
            SelectedContact.StreetName= StreetName;
            SelectedContact.PostalCode= PostalCode;
            SelectedContact.City = City;

            UpdatedSuccess = "Kontakten har uppdaterats!";
            ContactService.Update(SelectedContact);
            OnPropertyChanged(nameof(SelectedContact));
            OnPropertyChanged(nameof(Contacts));

            ShowUpdateForm = false;
            OnPropertyChanged(nameof(ShowUpdateForm));

        }

        partial void OnSelectedContactChanged(ContactModel value)
        {
            UpdatedSuccess = string.Empty;

            SelectedIsNotNull = true;
            OnPropertyChanged(nameof(SelectedIsNotNull));

            ShowUpdateForm = false;
            OnPropertyChanged(nameof(ShowUpdateForm));

        }

        
        [RelayCommand]
        private void RemoveButton()
        {
            if(MessageBox.Show("Är du säker på att du vill ta bort kontakten?", "RemoveQuestion" ,MessageBoxButton.YesNo,MessageBoxImage.Exclamation) == MessageBoxResult.Yes )
            {
                ContactService.Remove(SelectedContact);
                SelectedIsNotNull = false;
                OnPropertyChanged(nameof(SelectedIsNotNull));

            } else { }           
        }

        [RelayCommand]
        private void GoToUpdateButton()
        {
            FirstName = SelectedContact.FirstName;
            LastName = SelectedContact.LastName;
            Email = SelectedContact.Email;
            PhoneNumber = SelectedContact.PhoneNumber;
            StreetName = SelectedContact.StreetName;
            PostalCode = SelectedContact.PostalCode;
            City = SelectedContact.City;

            UpdatedSuccess = string.Empty;
            ShowUpdateForm = true;
            OnPropertyChanged(nameof(ShowUpdateForm));
            
        }

        [RelayCommand]
        private void Cancel()
        {
            ShowUpdateForm= false;
            OnPropertyChanged(nameof(ShowUpdateForm));
        }




    }
}
