using FriGado.API.Domain;
using System.Collections.Generic;

namespace FriGado.API.Repository
{
    public interface ICompraGadoItemRepository
    {
        public CompraGadoItem GetCompraGadoItem(int id);
        public IEnumerable<CompraGadoItem> ListAll();

        public int Add(CompraGadoItem compraGadoItem);
        public int Update(CompraGadoItem compraGadoItem);
        public int Remove(int id);
    }
}
