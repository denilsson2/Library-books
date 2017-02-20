using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MurvasBokhandel.Models
{
    public class AuthorTest
    {
        [Required(ErrorMessage = "Du måste fylla i personid")]
        public int Aid { get; set; }

        [Required(ErrorMessage = "Du måste fylla i personid")]
        public string BirthYear { get; set; }

        [Required(ErrorMessage = "Du måste fylla i förnamn")]
        [StringLength(30, ErrorMessage = "MyString can be no larger than 30 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Du måste fylla i efternamn")]
        [StringLength(30, ErrorMessage = "MyString can be no larger than 30 characters")]
        public string LastName { get; set; }
    }
}