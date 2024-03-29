using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.App.Controllers
{
    public class BaseController : Controller
    {
        public readonly INotificador _notificador;

        public BaseController(INotificador notificador)
        {
            _notificador = notificador;
        }

        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }
    }
}