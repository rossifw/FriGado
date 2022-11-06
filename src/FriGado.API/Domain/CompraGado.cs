using System;

namespace FriGado.API.Domain
{
    public class CompraGado
    {
        public int Id { get; set; }
        public Pecuarista Pecuarista { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}
