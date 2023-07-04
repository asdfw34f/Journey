using System;
using System.ComponentModel.DataAnnotations;

namespace Journey.MVVM.Models.Tables
{
    public class Users
    {
        [Key]
        public string? Email { get; set; }
        public byte[]? Password { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Date { get; set; }
        public byte[]? Image { get; set; }
        public string? Status { get; set; }
    }
}