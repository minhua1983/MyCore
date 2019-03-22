using Microsoft.AspNetCore.Mvc;
using MyCore.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCore.Demo.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public ViewResult Index()
        {
            Employee employee = new Employee()
            {
                Id = 1,
                Name = "minhua"
            };
            //return new ObjectResult(employee);
            return View(employee);
        }
    }
}
