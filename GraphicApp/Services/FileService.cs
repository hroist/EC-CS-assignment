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
                
        public FileService(string FilePath)
        {
            ReadFromFile(FilePath);
        }


        public ObservableCollection<ContactModel> ReadFromFile(string FilePath)
        {
            try
            {
                using var sr = new StreamReader(FilePath);
                return JsonConvert.DeserializeObject<ObservableCollection<ContactModel>>(sr.ReadToEnd())!;

            }
            catch { return null!; }
        }

        public void SaveToFile(string FilePath)
        {
            using var sw = new StreamWriter(FilePath);
            sw.WriteLine(JsonConvert.SerializeObject(ContactService.Contacts()));
        }

    }
}
