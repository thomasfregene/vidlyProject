using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using VidlyProject.ViewModel;

namespace VidlyProject.Controllers
{
    public class CustomersController : Controller
    {
        //dbcontext to assess database
        private ApplicationDbContext _context;

        public CustomersController()
        {
            //initializing the context
            _context = new ApplicationDbContext();
        }
        //disposing of context(context is a disposable method)
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        //index
        public ViewResult Index()
        {
            //var customers = GetCustomers();
            /*this is used to get all customer on the database
             query is executed when iteration is dine on the customers obj
             the query can be executed alternatively by calling the tolist method*/

            /*var customer = _context.Customers.Include(m => m.MembershipType).ToList();

            return View(customer);*/
           /* var viewModel = new RandomMovieViewModel();
            try
            {

                viewModel = new RandomMovieViewModel
                {
                    //Eager loading
                    Customers = _context.Customers.Include(m => m.MembershipType).ToList()
                };
            }
            catch (Exception ex)
            {

                Error error = new Error
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateOfLogin = DateTime.Now.ToString()
                };

                _context.Errors.Add(error);
                _context.SaveChanges();
            }*/
            //if (viewModel.)
            //{

            //}
            //finally
            //{

            // View(viewModel);
            //}
            return View(/*viewModel*/);
        }

        //New  
        public ActionResult New()
        {
            var viewModel = new RandomMovieViewModel();
            try
            {
                viewModel = new RandomMovieViewModel
                {
                    //to  set customer id to initial value(0)
                    Customer = new Customer(),
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
            }
            catch (Exception ex)
            {

                Error error = new Error
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateOfLogin = DateTime.Now.ToString()
                };

                _context.Errors.Add(error);
                _context.SaveChanges();
            }

            return View("CustomerForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            /*var customer = _context.Customers.Include(m=>m.MembershipType).SingleOrDefault(c => c.Id == id);*/
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            var viewModel = new RandomMovieViewModel
            {
                Customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(c => c.Id == id)
            };
            //if (customer == null)
            //return HttpNotFound();

            return View(viewModel);
        }

        /*post api
         this should never be accessible to get attribute 
         since it modifies data*/
        [HttpPost]
        [ValidateAntiForgeryToken]
        //model binding
        public ActionResult Save(Customer customer)
        {
            //validation very important
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return View(ModelState);
                //}

                //adding validation using ModelState
                if (!ModelState.IsValid)
                {
                    var viewModel = new RandomMovieViewModel
                    {
                        //this is required to populate "CustomerForm" with the user input
                       //and check if it's not valid
                        Customer = customer,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View("CustomerForm", viewModel);
                }

                if (customer.Id == 0)
                    _context.Customers.Add(customer);
                else
                {
                    var customerInDb = _context.Customers.Single(m => m.Id == customer.Id);

                    //edit
                    customerInDb.Name = customer.Name;
                    customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.BirthDate = customer.BirthDate;
                    customerInDb.MembershipType = customer.MembershipType;
                }

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                //Explicit initialization

                //Error error = new Error();
                //error.Message = ex.Message;
                //error.StackTrace = ex.StackTrace;
                //error.DateOfLogin = DateTime.Now;
                //_context.Errors.Add(error);
                //_context.SaveChanges();



                //Object literal initialization
                Error error = new Error
                {
                    Message = ex.Message.ToString(),
                    StackTrace = ex.StackTrace.ToString(),
                    DateOfLogin = DateTime.Now.ToString()
                };

                _context.Errors.Add(error);
                _context.SaveChanges();

                //writing to a text file using streamWriter
                //() parentheses, {} braces, [] bracket
                //using
                string dir = @"C:\Users\Katherine Fregene\Desktop\Errors\ErrorText.txt";
                using (var writer = new StreamWriter(dir))
                {
                    writer.WriteLine("----------------------------------------------------------");
                    writer.WriteLine($"Date: {DateTime.Now.ToString()}");
                    writer.WriteLine();
                    //if exception is loaded with errors do the  condition below
                    if (ex != null)
                    {
                        writer.WriteLine($"Message: {ex.Message.ToString()}");
                        writer.WriteLine($"StackTrace: {ex.StackTrace.ToString()}");
                        writer.WriteLine("----------------------------------------------------------");
                    }


                }
            }
            //finally
            //{

            //}
            return RedirectToAction("Index", "Customers");
        }

        //delete
        public ActionResult Delete(int id)
        {
            try
            {
                var customerFromDb = _context.Customers.Single(m => m.Id == id);
                if (customerFromDb == null)
                {
                    return HttpNotFound();
                }
                _context.Customers.Remove(customerFromDb);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                Error error = new Error
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateOfLogin = DateTime.Now.ToString()
                };

                _context.Errors.Add(error);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Customers");
        }

        //Edit
        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Customer = _context.Customers.Include(m => m.MembershipType).SingleOrDefault(m => m.Id == id),
        //        MembershipTypes = _context.MembershipTypes.ToList()
        //    };
        //    return View("CustomerForm", viewModel);
        //}

        //[HttpPut]
        //public ActionResult Edit(int id, Customer customerFromForm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return View(ModelState);
        //        }
        //        var customerInDb = _context.Customers.SingleOrDefault(m => m.Id == id);
        //        if (customerInDb == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        //Edit Data
        //        customerInDb.Name = customerFromForm.Name;
        //        customerInDb.IsSubscribedToNewsLetter = customerFromForm.IsSubscribedToNewsLetter;
        //        customerInDb.MembershipTypeId = customerFromForm.MembershipTypeId;
        //        customerInDb.BirthDate = customerFromForm.BirthDate;
        //        _context.SaveChanges();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return RedirectToAction("Index", "Customers");
        //}

        //add coded GetCustomerDb
        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "John Smith" },
        //        new Customer { Id = 2, Name = "Mary Williams" }
        //    };
        //}
    }

}
