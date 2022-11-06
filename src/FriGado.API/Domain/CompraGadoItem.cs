namespace FriGado.API.Domain
{
    public class CompraGadoItem
    {
        public int Id { get; set; }
        public CompraGado CompraGado { get; set; }
        public Animal Animal { get; set; }
        public int Quantidade { get; set; }
    }
}
