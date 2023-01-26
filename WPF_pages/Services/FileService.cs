using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_pages.Models;

namespace WPF_pages.Services
{
    internal class FileService
    {
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\todos.json";

        private List<Todo> todos;

        public FileService()
        {
            ReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                todos = JsonConvert.DeserializeObject<List<Todo>>(sr.ReadToEnd())!;

            }
            catch { todos = new List<Todo>(); }
        }

        private void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(todos));
        }

        public void AddToList(Todo todo)
        {
            todos.Add(todo);
            SaveToFile();
        }

        public ObservableCollection<Todo> Todos()
        {
            var items = new ObservableCollection<Todo>();
            foreach (var todo in todos) {
                items.Add(todo);
            }
            return items;
        }
    }
}
