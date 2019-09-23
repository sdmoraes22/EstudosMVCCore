using System;

namespace CMSOFT.AppModelo.Models
{
    public class Pedido
    {
        public Guid Id { get; set; }

        public Pedido()
        {
            Id = Guid.NewGuid();
            
        }
    }
}