using System;
using System.ComponentModel.DataAnnotations;

namespace Journey.MVVM.Models
{
    public class Users
    {
        [Key]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Date { get; set; }
        public byte[]? Image { get; set; }
    }
}