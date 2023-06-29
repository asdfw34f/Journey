using System.ComponentModel.DataAnnotations;

namespace Journey.MVVM.Models
{
    public class Groups
    {
        [Key]
        public string? Login { set; get; }
        public string? Password { set; get; }
        public string? GroupID { set; get; }
        public string? Title { set; get; }
    }
}