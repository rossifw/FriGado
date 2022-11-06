using FriGado.API.Domain;
using System.Collections.Generic;

namespace FriGado.API.Repository
{
    public interface ICompraGadoRepository
    {
        public CompraGado GetCompraGado(int id);
        public IEnumerable<CompraGado> ListAll();

        public int Add(CompraGado compraGado);
        public int Update(CompraGado compraGado);
        public int Remove(int id);
    }
}
