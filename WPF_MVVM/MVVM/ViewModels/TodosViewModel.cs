using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MVVM.MVVM.Models;
using WPF_MVVM.Services;

namespace WPF_MVVM.MVVM.ViewModels
{
    public partial class TodosViewModel : ObservableObject
    {
        private readonly FileService fileService;

        public TodosViewModel()
        {
            fileService = new FileService();
            todos = fileService.Todos();
        }

        [ObservableProperty]
        private string pageTitle = "Todos";

        [ObservableProperty]
        private ObservableCollection<TodoModel> todos;
    }
}
