using GraphicApp.Services;
using GraphicApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace GraphicApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        private readonly FileService file = new();

        public MainWindow()
        {
            InitializeComponent();
            file.FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\myContacts.json";

            PopulateContactList();
        }

        private void PopulateContactList()
        {
            try
            {
                var ContactsFromFile = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(file.Read());
                if(ContactsFromFile != null)
                {
                    contacts = ContactsFromFile; ;
                } 
            } catch { }

            lv_Contacts.ItemsSource = contacts;

        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            contacts.Add(new Contact
            {
                FirstName = tb_FirstName.Text,
                LastName = tb_LastName.Text,
                Email = tb_Email.Text,
                PhoneNumber = tb_PhoneNumber.Text,
                StreetName = tb_StreetName.Text,
                PostalCode = tb_PostalCode.Text,
                City = tb_City.Text,
            });

            file.Save(JsonConvert.SerializeObject(contacts));
            ClearForm();
        }

        private void ClearForm()
        {
            tb_FirstName.Text = "";
            tb_LastName.Text = "";
            tb_Email.Text = "";
            tb_PhoneNumber.Text = "";
            tb_StreetName.Text = "";
            tb_PostalCode.Text = "";
            tb_City.Text = "";
        }
    }
}
