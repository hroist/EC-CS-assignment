using CommunityToolkit.Mvvm.ComponentModel;
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

        private static ObservableCollection<ContactModel> contacts;

        public static string filePath { get; set; } = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\adressbok.json";

        static ContactService()
        {
            fileService = new FileService(filePath);
            contacts = fileService.ReadFromFile(filePath); 

            if ( contacts == null )
            {
                contacts = new();
            }
        }

        public static void Add(ContactModel contact)
        {
            contacts.Add(contact);
            fileService.SaveToFile(filePath);
            
        }

        public static void Update(ContactModel contact)
        {           
            fileService.SaveToFile(filePath);
        }


        public static void Remove(ContactModel contact)
        {
            contacts.Remove(contact);
            fileService.SaveToFile(filePath);
        }

        public static ObservableCollection<ContactModel> Contacts()
        {          
            return contacts;
        }
    }
}
