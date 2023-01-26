using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM.MVVM.Models
{
    public class TodoModel
    {
        public string Text { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;
    }
}
