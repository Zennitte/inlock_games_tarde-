using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webAPI.Controllers
{
    public class EstudiosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
