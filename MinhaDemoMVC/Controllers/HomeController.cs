using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MinhaDemoMVC.Models;

namespace MinhaDemoMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // var filme = new Filme()
            // {
                // Titulo = "Oi",
                // DataLancamento = DateTime.Now,
                // Genero = null,
                // Avaliacao = 10,
                // Valor = 20000
            // };

            // return RedirectToAction("Privacy", filme);

            return View();
        }

        public IActionResult Privacy(Filme filme)
        {
            if(ModelState.IsValid)
            {

            }

            foreach(var error in ModelState.Values.SelectMany(m => m.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            return View();
            // return Json("{'nome': 'Cristiano'}");
            // var fileBytes = System.IO.File.ReadAllBytes(@"../../../../teste.txt");
            // var filename = "arquivo.txt";
            // return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
            // return Content("Qualquer coisa");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
