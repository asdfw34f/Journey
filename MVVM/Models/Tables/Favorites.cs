using System.ComponentModel.DataAnnotations;

namespace Journey.MVVM.Models.Tables
{
    public class Favorites
    {
        [Key]
        public string? Token { get; set; }
        public int? ID { get; set; }
        public string? Email { get; set; }
    }
}