using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Movie
    {
        //plain old crl object(POCO)
        /*represents the state and behaviour of the app
         in terms of problem domain this page only contains state*/
        public int Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        public int GenreId { get; set; }

        [Display(Name ="Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Display(Name ="Number In stock")]
        public byte NumberInStock { get; set; }



    }
}