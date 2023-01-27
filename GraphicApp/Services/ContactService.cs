using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;
using GraphicApp.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicApp.Services
{
    public static class ContactService
    {
        private static readonly FileService fileService;

        private static readonly ObservableCollection<ContactModel> contacts;

        static ContactService()
        {
            fileService= new FileService();
            contacts = fileService.ReadFromFile();
        }

        public static void Add(ContactModel contact)
        {
            contacts.Add(contact);
            fileService.SaveToFile();
            
        }

        public static void Update(ContactModel contact)
        {
            fileService.SaveToFile();            
        }


        public static void Remove(ContactModel contact)
        {
            contacts.Remove(contact);
            fileService.SaveToFile();
        }

        public static ObservableCollection<ContactModel> Contacts()
        {          
            return contacts;
        }
    }
}
