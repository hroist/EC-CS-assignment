using GraphicApp.MVVM.Models;
using GraphicApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicApp.Services
{
    public class FileService
    {
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\adressbok.json";

        
        public FileService()
        {
            ReadFromFile();
        }


        public ObservableCollection<ContactModel> ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                return JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;

            }
            catch { return null!; }
        }

        public void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(ContactService.Contacts()));
        }

    }
}
