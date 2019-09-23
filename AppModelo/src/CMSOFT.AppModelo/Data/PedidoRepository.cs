using CMSOFT.AppModelo.Models;

namespace CMSOFT.AppModelo.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        public Pedido ObterPedido()
        {
            return new Pedido();
        }
    }
}

public interface IPedidoRepository
{
    Pedido ObterPedido();
}