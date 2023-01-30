using ConsoleApp.Interfaces;
using ConsoleApp.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace ConsoleApp.Services;

public class FileService
{

    public void Save(string filePath, string contactList)
    {
        using var writer = new StreamWriter(filePath);
        writer.WriteLine(contactList);
    }

    public string Read(string filePath) 
    {
        try
        {
            using var reader = new StreamReader(filePath);
            return reader.ReadToEnd(); 
        }
        catch { return null!; }
    }
    
    public void ImportFromFile(string filePath, List<IContact> list)
    {
        // Reads existing contacts from file
        var ListFromFile = Read(filePath);
        if(ListFromFile != null)
        {
        var AllContacts = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(ListFromFile);
            if (AllContacts != null)
            {
                AllContacts.ToList().ForEach(x => list.Add(x));
            }
        }
        
    }

}
