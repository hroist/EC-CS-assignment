using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DevExpress.Mvvm.Native;
using GraphicApp.MVVM.Models;
using GraphicApp.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        private string pageTitle = "KONTAKTER";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(SelectedIsNotNull))]
        private ContactModel selectedContact = null!;

        [ObservableProperty]
        private bool selectedIsNotNull = false;

        [ObservableProperty]
        private bool showUpdateForm = false;

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

            var index = Contacts.IndexOf(SelectedContact);

            Contacts.Insert((index), SelectedContact);
            Contacts.RemoveAt(index + 1);

            SelectedContact = Contacts[index];

            UpdatedSuccess = "Kontakten har uppdaterats!";
            ContactService.Update(SelectedContact);
            OnPropertyChanged(nameof(SelectedContact));

            ShowUpdateForm = false;
            //OnPropertyChanged(nameof(ShowUpdateForm));
        }

        partial void OnSelectedContactChanged(ContactModel value)
        {
            UpdatedSuccess = string.Empty;

            SelectedIsNotNull = true;

            ShowUpdateForm = false;
        }


        [RelayCommand]
        private void RemoveButton()
        {
            if(MessageBox.Show("Är du säker på att du vill ta bort kontakten?", "RemoveQuestion" , MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes )
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
            ShowUpdateForm = false;
            OnPropertyChanged(nameof(ShowUpdateForm));
        }
    }
}
