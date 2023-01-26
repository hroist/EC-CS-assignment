using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM.MVVM.Models;

namespace WPF_MVVM.Services
{
    public class FileService
    {
        private string filePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\todos.json";

        private List<TodoModel> todos;

        public FileService()
        {
            ReadFromFile();
        }


        private void ReadFromFile()
        {
            try
            {
                using var sr = new StreamReader(filePath);
                todos = JsonConvert.DeserializeObject<List<TodoModel>>(sr.ReadToEnd())!;

            }
            catch { todos = new List<TodoModel>(); }
        }

        private void SaveToFile()
        {
            using var sw = new StreamWriter(filePath);
            sw.WriteLine(JsonConvert.SerializeObject(todos));
        }

        public void AddToList(TodoModel todo)
        {
            todos.Add(todo);
            SaveToFile();
        }

        public ObservableCollection<TodoModel> Todos()
        {
            var items = new ObservableCollection<TodoModel>();
            foreach (var todo in todos)
            {
                items.Add(todo);
            }
            return items;
        }
    }
}
