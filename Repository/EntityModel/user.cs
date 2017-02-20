using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Validation;

namespace Repository.EntityModel
{

    public class user
    {
        [Required(ErrorMessage = "Du måste fylla i personid")]
        [PersonIdValidation(ErrorMessage="Du måste fylla i personnummret på \"ÅÅÅÅMMDD-XXXX\"")]
        public string PersonId { get; set; }

        [Required(ErrorMessage = "Du måste fylla i Epost")]
        [EmailValidation(ErrorMessage ="Du måste fylla i en korrekt Epost")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Du måste välja RoleId")]
        public int RoleId { get; set; }

        //[Required(ErrorMessage = "Du måste fylla i Lösenord")]
        //[PasswordValidator(ErrorMessage="Läsenordet måste vara mellan 5 och 15 tecken samt innehålla en Versal och Siffra")] 
        public string Password { get; set; }
    }
}
