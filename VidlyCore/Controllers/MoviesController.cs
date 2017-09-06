using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;
using VidlyCore.Data;
using Microsoft.EntityFrameworkCore;
using VidlyCore.Models.MoviewViewModels;

namespace VidlyCore.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult Index()
        {
            var movies = _context.Movies
                .Include(m => m.Genre).ToList() ;
            return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _context.Movies
                .Include(m => m.Genre)
                .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();
            return View(movie);
        }

        public IActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel()
            {
                Genres = genre
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres  = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }


            if (movie.Id == 0)
            //                movie.DateAdded = System.DateTime.Now;
                _context.Movies.Add(movie);
            else
            {
                var updateMovie= _context.Movies.Single(m => m.Id == movie.Id);

                updateMovie.Name = movie.Name;
                updateMovie.NumberInStock = movie.NumberInStock;
                updateMovie.ReleaseDate = movie.ReleaseDate;
                updateMovie.DateAdded = movie.DateAdded;
                updateMovie.GenreId = movie.GenreId;
               
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
            
        }


        public IActionResult Edit(int id)
        {
            var movie = _context.Movies
               .SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            var viewModel = new MovieFormViewModel(movie)
            {              
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }




        private IEnumerable<Movie> GetMovies()
        {
             return new List<Movie>
             {
                 new Movie { Id = 1, Name = "Shrek" },
                 new Movie { Id = 2, Name = "Wall-e" }
             };
        }


        [Route("movies/released/{year}/{month:regex(^\\d{{2}}$)}")]
        public ActionResult ByReleaseYear(int year, int month)
        {
            return Content(year + "/" + month);
        }


        // GET: Movies/Random
        public ActionResult Random()
        {

            var movie = new Movie { Name = "Sherk Reunion!" };


            return View(movie);
        }
    }
}