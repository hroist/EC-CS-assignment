using CommunityToolkit.Mvvm.ComponentModel;
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
        private readonly FileService fileService;

        public ContactsViewModel()
        {
            fileService= new FileService();
            contacts = fileService.Contacts();
        }

        [ObservableProperty]
        private string pageTitle = "Kontakter";

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;
    }
}
