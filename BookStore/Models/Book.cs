using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStore.Helper;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }

        //[Required(ErrorMessage = "Please enter the title of your book")]
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter book title")]
        [MyCustomValAttr("book")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public string Category { get; set; }
        
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "Please enter the total pages")]
        [Display(Name = "Total pages of book")]
        public int? TotalPages { get; set; }
    }
}
