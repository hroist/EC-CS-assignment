using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using ConsoleApp.Models.AbstractModels;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp.Services;

internal class MainMenuService
{
    private List<IContact> contacts = new List<IContact>();
    private FileService file = new FileService();

    public string FilePath { get; set; } = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\contactList.json";

    public MainMenuService() 
    {
        file.ImportFromFile(FilePath, contacts);
    }

    public void WelcomeMenu()
    {
        Console.Clear();
        Console.WriteLine("\n Välkommen till addressboken");
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("1. Skapa en kontakt");
        Console.WriteLine("2. Visa alla kontakter");
        Console.WriteLine("3. Visa en specifik kontakt");
        Console.WriteLine("4. Ta bort en specifik kontakt");
        Console.WriteLine("---------------------------------------- \n");
        Console.WriteLine("Välj ett av alternativen ovan: \n");
        var option = Console.ReadLine();

        switch(option)
        {
            case "1": CreateContact();
                break;
            case "2": GetAllContacts();
                break;
            case "3": GetContact();
                break;
            case "4": DeleteContact();
                break;
        }
    }

    private void CreateContact()
    {
        Console.Clear();
        Console.WriteLine("Skapa en kontakt");
        Console.WriteLine("----------------------------------------\n");

        IContact contact = new Contact();
        Console.Write("Ange förnamn: ");
        contact.FirstName = Console.ReadLine() ?? "";
        Console.Write("Ange efternamn: ");
        contact.LastName = Console.ReadLine() ?? "";
        Console.Write("Ange email: ");
        contact.Email = Console.ReadLine() ?? "";
        Console.Write("Ange telefonnummer: ");
        contact.PhoneNumber = Console.ReadLine() ?? "";
        Console.Write("Ange gatuadress: ");
        contact.StreetName = Console.ReadLine() ?? "";
        Console.Write("Ange postkod: ");
        contact.PostalCode = Console.ReadLine() ?? "";
        Console.Write("Ange postort: ");
        contact.City = Console.ReadLine() ?? "";

        contacts.Add(contact);

        file.Save(FilePath, JsonConvert.SerializeObject(contacts));

        Console.Clear();
        Console.WriteLine("Kontakten är skapad. Tryck på valfri tangent för att gå tillbaka till huvudmenyn.");
        Console.ReadKey();

    }

    private void GetAllContacts()
    {
        Console.Clear();
        Console.WriteLine("Kontakter:");
        Console.WriteLine("----------------------------------------\n");


        if (contacts.Count > 0)
        {
            contacts.ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} <{x.Email}>"));

        }
        else { Console.WriteLine("Det finns inga kontakter. Tryck på valfri tangent för att gå tillbaka till huvudmenyn."); }
        
        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till huvudmenyn.");
        Console.ReadKey();
    }

    private void GetContact()
    {
        Console.Clear();
        Console.WriteLine("Hämta en kontakt");
        Console.WriteLine("----------------------------------------\n");

        Console.Write("Ange efternamn: ");
        var search = Console.ReadLine();

        if (search != null)
        {
            var contactBySearch = contacts.Find(contact => contact.LastName.ToLower().Contains(search.ToLower()));
            if (contactBySearch != null)
            {
                Console.Write($"\nFörnamn: {contactBySearch.FirstName}\n" +
                              $"Efternamn: {contactBySearch.LastName}\n" +
                              $"E-postadress: {contactBySearch.Email}\n" +
                              $"Telefonnummer: {contactBySearch.PhoneNumber}\n" +
                              $"Adress: {contactBySearch.Address}\n");
            } 
            else
            {
                Console.WriteLine("\nDet hittades ingen kontakt som matchade sökningen.");
            }

        }

        Console.WriteLine("\n----------------------------------------");
        Console.WriteLine("Tryck på valfri tangent för att gå tillbaka till huvudmenyn.");
        Console.ReadKey();
    }

    private void DeleteContact()
    {
        Console.Clear();
        Console.WriteLine("Ta bort en kontakt");
        Console.WriteLine("----------------------------------------\n");

        Console.Write("Ange efternamn på den kontakt du vill ta bort: ");
        var search = Console.ReadLine();

        if (search != null)
        {
            var contactBySearch = contacts.Find(contact => contact.LastName.ToLower().Contains(search.ToLower()));
            if (contactBySearch != null)
            {
                Console.Write($"\nFörnamn: {contactBySearch.FirstName}\n" +
                              $"Efternamn: {contactBySearch.LastName}\n" +
                              $"E-postadress: {contactBySearch.Email}\n" +
                              $"Telefonnummer: {contactBySearch.PhoneNumber}\n" +
                              $"Adress: {contactBySearch.Address}\n");
            }
            else
            {
                Console.WriteLine("\nDet hittades ingen kontakt som matchade sökningen.");
            }

            Console.WriteLine("\n----------------------------------------");
            Console.WriteLine("Är du säker på att du vill ta bort denna kontakt? (y/n)");
            var userOption = Console.ReadLine();
            if(userOption == "y")
            {
                if(contactBySearch != null) { contacts.Remove(contactBySearch); }
                file.Save(FilePath, JsonConvert.SerializeObject(contacts));

                Console.Clear();
                Console.WriteLine("Ta bort en kontakt");
                Console.WriteLine("----------------------------------------\n");
                Console.WriteLine("Kontakten har tagits bort. Tryck på valfri tangent för att gå tillbaka till huvudmenyn.");
                Console.ReadKey();

            } else
            {
                WelcomeMenu();
            }
        }
    }
} 
