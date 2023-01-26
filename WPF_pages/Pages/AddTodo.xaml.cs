using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddTodo.xaml
    /// </summary>
    public partial class AddTodo : Page
    {
        private readonly FileService fileService;

        public AddTodo()
        {
            InitializeComponent();
            fileService = new FileService();
        }

        private void btn_Add_Click(object sender, RoutedEventArgs e)
        {
            fileService.AddToList(new Todo { Text = tb_Todo.Text });
            tb_Todo.Text = string.Empty;
        }
    }
}
