﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyProject.Models
{
    public class Genre
    {
        public int Id { get; set; }

        //attribute business rule
        [Required]
        [StringLength(100)]
        public string Name { get; set; }


    }
}