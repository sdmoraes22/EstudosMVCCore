using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using AspNetCoreIdentity.Authorization;
using System;
using KissLog;

namespace AspNetCoreIdentity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger logger)
        {
            _logger = logger;
        }


        [AllowAnonymous]
        public IActionResult Index()
        {
            _logger.Trace("Usuario acessou a Home!");
            return View();
        }
        
        public IActionResult Privacy()
        {
            throw new Exception("Erro");
            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Secret()
        {
            try
            {
                throw new Exception("Algo horrível ocorreu");
            }
            catch (Exception e)
            {

                _logger.Error(e);
                throw;
            }
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimGravar()
        {
            return View("Secret");
        }

        [ClaimsAuthorize("Produtos","Ler")]
        public IActionResult ClaimsCustom()
        {
            return View("Secret");
        }

        [Route("/erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelError = new ErrorViewModel();

            if (id == 500)
            {
                modelError.Mensagem = "Tente novamente mais tarde ou contate o nosso suporte.";
                modelError.Titulo = "Ocorreu um erro!";
                modelError.ErrorCode = id;
            }
            
            else if (id == 404)
            {
                modelError.Mensagem = "A página que está procurando não existe! <br />Em caso de dúvidas entre em contato com o nosso suporte";
                modelError.Titulo = "Ops página não encontrada!";
                modelError.ErrorCode = id;
            }
            
            else if (id == 403)
            {
                modelError.Mensagem = "Você não tem permissão para fazer isso!";
                modelError.Titulo = "Acesso Negado!";
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
