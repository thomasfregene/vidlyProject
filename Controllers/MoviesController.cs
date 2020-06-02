using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using VidlyProject.ViewModel;

namespace VidlyProject.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Movies/Random
        //List of Movies
        public ActionResult Index()
        {
            var ViewModel = new RandomMovieViewModel
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            };
            //var movie = _context.Movies.Include(m => m.Genre).ToList();

            return View("Random", ViewModel);
            /*var movie = new Movie() { Name = "Shrek!" };
            //list of customers
            var customer = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer{Name = "Customer 2"}
            };

            //viewModel object
           var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customer
            };

            return View(viewModel);*/

            //New 


            //all contollers have a property called ViewData
            /*ViewData["Movie"] = movie;*/

            /*action results the following are the various
             types of actionResults including "return View"*/
            // return Content("Hello World!");
            //return HttpNotFound();
            // return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        //New Movie
        public ActionResult New()
        {
            var viewModel = new RandomMovieViewModel()
            {
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            //implementing validation
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new RandomMovieViewModel
                    {
                        Movie = movie,
                        Genres = _context.Genres.ToList()
                    };

                    return Content("Invalid Form");
                    // return View("MovieForm", viewModel);
                }

                if (movie.Id == 0)
                    _context.Movies.Add(movie);
                else
                {
                    var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                    //edit
                    movieInDb.Name = movie.Name;
                    movieInDb.NumberInStock = movie.NumberInStock;
                    movieInDb.GenreId = movie.GenreId;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                }
                _context.SaveChanges();

                return RedirectToAction("Index", "Movies");
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Edit/Update
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("Edit", viewModel);
        }

        //delete
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(m => m.Id == id);
            if (customerInDb == null)
            {
                return HttpNotFound();
            }
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return View("Random", "Movies");
        }


        //Attribute route
        /*to apply constrains to attribute route ose :regex, range etc*/
        [Route("movies / released /{year}/{month:regex(\\d{4}):range(1, 12)}")]

        //custom route controller
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
        //action parametersd
        /*public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }*/

        //movies(optional parameter)
        /*public ActionResult Index(int? pageIndex, string sortBy)
        {
            //to make a parameter optional it should 
            //be nullable
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }*/
    }
}