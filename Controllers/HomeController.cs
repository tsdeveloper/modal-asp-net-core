using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using sample.modal.Models;

namespace sample.modal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new  List<UsuarioViewModel>());
        }

        public IActionResult GetUsuario()
        {
            var list = new  List<UsuarioViewModel>
            {
                new UsuarioViewModel {Id = 1, Nome = "Usuario-1"},
                new UsuarioViewModel {Id = 2, Nome = "Usuario-2"},
                new UsuarioViewModel {Id = 3, Nome = "Usuario-3"}
            };

            return PartialView("_Usuario",list);
        }
        
        public IActionResult GetState()
        {
            var list = new  List<StateViewModel>
            {
                new StateViewModel {State = "BA"},
                new StateViewModel {State = "DF"},
                new StateViewModel {State = "RS"},
                
            };
            var statelist= new SelectList(list,"State","State");
            return Json(statelist);
        }
        
        public IActionResult GetCity(string state)
        {
            var list = new  List<CityViewModel>
            {
                new CityViewModel {City= "Salvador",State = "BA"},
                new CityViewModel {City= "Feira de Santana",State = "BA"},
                new CityViewModel {City= "Brasília",State = "DF"},
                new CityViewModel {City= "Águas Claras",State = "DF"},
                new CityViewModel {City= "Paraná", State = "RS"},
                new CityViewModel {City= "Blumenau",State = "RS"},
                
            };

            var citylist= new SelectList(list,"State","City", state);


            return Json(citylist);
        }
    }
}