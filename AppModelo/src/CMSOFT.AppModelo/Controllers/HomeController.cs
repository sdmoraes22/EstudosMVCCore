using CMSOFT.AppModelo.Data;
using Microsoft.AspNetCore.Mvc;

namespace CMSOFT.AppModelo.Controllers
{
    public class HomeController : Controller
    {
        private IPedidoRepository _pedidoRepository;

        // public HomeController(IPedidoRepository pedidoRepository)
        // {
            // _pedidoRepository = pedidoRepository;
            // 
        // }
        public IActionResult index([FromServices] IPedidoRepository _pedidoRepository)
        {
           
           var pedido = _pedidoRepository.ObterPedido();
           return View();
        }
        
    }
}