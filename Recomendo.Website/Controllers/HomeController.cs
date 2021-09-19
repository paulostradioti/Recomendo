using Microsoft.AspNetCore.Mvc;
using Recomendo.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recomendo.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repository;

        public HomeController(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult Index()
        {
            return View(repository.Movies);
        }
    }
}
