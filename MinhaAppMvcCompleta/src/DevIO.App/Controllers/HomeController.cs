using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DevIO.App.ViewModels;

namespace DevIO.App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Errors(int id)
        {
            var modelError = new ErrorViewModel();
            
            if(id == 500)
            {
                modelError.Mensagem = "Ocorreu um erro! tente novamente ou entre em contato com o suporte.";
                modelError.Titulo = "Ocorreu um erro.";
                modelError.ErrorCode = id;
            }
            
            else if(id ==404)
            {
                modelError.Mensagem = "A página que você está procurando não existe!<br />Em caso de dúvidas entre em contato com o nosso suporte";
                modelError.Titulo = "Página não encontrada!";
                modelError.ErrorCode = id;
            }

            else if(id == 403)
            {
                modelError.Mensagem = "Você não tem permissão pra fazer isto.";
                modelError.Titulo = "Acesso negado!";
                modelError.ErrorCode = id;
            }
            
            else
            {
                return StatusCode(404);
            }

            return View("Error", modelError);
        }
    }
}
