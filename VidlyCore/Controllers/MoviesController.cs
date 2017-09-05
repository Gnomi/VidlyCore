using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using VidlyCore.Models;
using VidlyCore.Data;
using Microsoft.EntityFrameworkCore;

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

//            if (movie == null)
  //              return View(NoContentResult());
            return View(movie);
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