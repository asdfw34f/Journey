using System;
using System.ComponentModel.DataAnnotations;

namespace Journey.MVVM.Models.Tables
{
    public class Groups
    {
        [Key]
        public string? Name { set; get; }
        public string? Email{ set; get; }
        public string? ID { set; get; }
        public string? Description { set; get; }
        public DateTime Created { get; set; }
    }
}