using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Validation;


namespace Repository.EntityModel
{
    public class borrower
    {

        [Required(ErrorMessage = "Du måste fylla i personid")]
        [PersonIdValidation(ErrorMessage="Du måste fylla i personnummret på \"ÅÅÅÅMMDD-XXXX\"")]
        public string PersonId { get; set; }

        [Required(ErrorMessage = "Du måste fylla i Category mellan 1 och 4")]
        public int CategoryId { get; set; }
    

        [Required(ErrorMessage = "Du måste fylla i Förnamn")]
        [NameValidation(ErrorMessage="Namn får bara innehålla bokstäver")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Du måste fylla i Efernamn")]
        [NameValidation(ErrorMessage = "Namn får bara innehålla bokstäver")]
        public string LastName { get; set; }

        [AdressValidation(ErrorMessage="Vanliga tecken samt . - ")]
        public string Address { get; set; }

        [Phone(ErrorMessage = "Du måste fylla i ett korrekt telefonnummer")]

        public string Telno { get; set; }
    }
}
