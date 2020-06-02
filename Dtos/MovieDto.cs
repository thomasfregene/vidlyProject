using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(225)]
        public string Name { get; set; }

        ///*delete*/public Genre Genre { get; set; }

        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public byte NumberInStock { get; set; }
    }
}