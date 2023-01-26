using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraphicApp.MVVM.Models;
using GraphicApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private ContactModel selectedContact = null!;


    }
}
