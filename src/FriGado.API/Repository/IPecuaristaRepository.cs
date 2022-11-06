using FriGado.API.Domain;
using System.Collections.Generic;

namespace FriGado.API.Repository
{
    public interface IPecuaristaRepository
    {
        public Pecuarista GetPecuarista(int id);
        public IEnumerable<Pecuarista> ListAll();

        public int Add(Pecuarista pecuarista);
        public int Update(Pecuarista pecuarista);
        public int Remove(int id);
    }
}
