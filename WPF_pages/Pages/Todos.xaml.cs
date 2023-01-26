using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_pages.Models;
using WPF_pages.Services;

namespace WPF_pages.Pages
{
    /// <summary>
    /// Interaction logic for Todos.xaml
    /// </summary>
    public partial class Todos : Page
    {

        private readonly FileService fileService;

        public ObservableCollection<Todo> TodoList { get; set; }

        public Todos()
        {
            InitializeComponent();
            fileService = new FileService();
            TodoList = (ObservableCollection<Todo>)fileService.Todos();

            lv_Todos.ItemsSource = TodoList;
        }

        
    }
}
