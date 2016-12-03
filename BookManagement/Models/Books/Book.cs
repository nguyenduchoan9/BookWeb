using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookManagement.Models.Books
{
    public class EditBookView : AddBookView
    {
        [Required]
        public int ID { get; set; }

    }
    public class AddBookView
    {
        [Required(ErrorMessage="Enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage="Enter Description")]
        public string Description { get; set; }
        //public string Img_Link { get; set; }
        [Required(ErrorMessage="Choose a status")]
        public int StatusID { get; set; }
        public Nullable<int> Rate { get; set; }
        [Required(ErrorMessage="Enter Price")]
        public double Price { get; set; }
        [Required(ErrorMessage="Choose an author")]
        public int AuthorID { get; set; }
        [Required(ErrorMessage="Choose a genre")]
        public int GenreID { get; set; }
        [Required(ErrorMessage="Choose a publisher")]
        public int PublisherID { get; set; }
        public DateTime PublishedDate { get; set; }
    }
    //public virtual Authors
    public class SearchBookModel
    {
        public string KeySearch { get; set; }
    }
}