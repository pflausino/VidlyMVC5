using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        //DB Date Recovery Start
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //DB Date Recovery END


        public ViewResult Index()
        {


            return View();
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };

            return View("MovieForm", viewModel);
        }
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == Id);

            if (movie == null) return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
            }

            if (movie.Id == 0)
            {
                movie.AddDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                //Danger Implementation ->
                //TryUpdateModel(customerInDb);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;

                //Other Option
                //Mapper.Map(customer, customerInDb);

            }


            _context.SaveChanges();


            return RedirectToAction("Index", "Movies");
        }



        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id ==Id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }



        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }
    }
}