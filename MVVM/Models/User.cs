using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journey.MVVM.Models
{
    public class User
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surename { get; set; }
        public DateTime? Date { get; set; }
        public BinaryData Image { get; set; }
    }
}