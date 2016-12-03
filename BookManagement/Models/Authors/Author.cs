using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManagement.Models.Authors
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
    }
    public class EditAuthorView
    {
        [Required]
        public int ID;
    }
    public class AddAuthorView
    {
        public string Name;
        public string Description;

    }
}