using Repository.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.EntityModel
{
    public class book
    {
        [IsbnValidation(ErrorMessage = "ISBN måste vara mindre än 10 tecken och sluta på X eller en siffra.")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Sign krävs.")]
        public int SignId { get; set; }

        public string PublicationYear { get; set; }
        [Required(ErrorMessage = "Titel krävs.")]
        public string Title { get; set; }
        public string publicationinfo { get; set; }
        [Required(ErrorMessage = "Sidor krävs")]
        [Range(1, int.MaxValue, ErrorMessage = "Måste vara ett tal mellan 1 - 4294967296.")]
        public int pages { get; set; }
    }
}
