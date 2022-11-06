using FriGado.API.Domain;
using System.Collections.Generic;

namespace FriGado.API.Repository
{
    public interface IUsuarioRepository
    {
        public Usuario GetUsuario(int id);
        public Usuario GetUsuario(string login);
        public IEnumerable<Usuario> ListAll();

        public int Add(Usuario usuario);
        public int Update(Usuario usuario);
        public int Remove(int id);
    }
}
