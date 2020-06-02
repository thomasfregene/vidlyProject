using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyProject.Models;

namespace VidlyProject.ViewModel
{
    public class RandomMovieViewModel
    {
        public IEnumerable<Movie> Movies { get; set; }

        public Movie Movie { get; set; }

        public IEnumerable<Customer> Customers { get; set; }

        public Customer Customer { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}