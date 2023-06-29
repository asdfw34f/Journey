using System;
using System.ComponentModel.DataAnnotations;

namespace Journey.MVVM.Models
{
    public class Posts
    {
        [Key]
        public string? PostId { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public byte[]? Media { get; set; }
        public int? GroupID { get; set; }
        public DateTime? Created { get; set; }


    }
}
