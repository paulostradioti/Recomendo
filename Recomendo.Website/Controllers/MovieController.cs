using Microsoft.AspNetCore.Mvc;
using Recomendo.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recomendo.Website.Controllers
{
    public class MovieController : Controller
    {
        private readonly IRepository repository;

        public MovieController(IRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View(repository.Movies);
        }

        public IActionResult Details(int id)
        {
            var movie = repository.Movies.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }
    }
}
