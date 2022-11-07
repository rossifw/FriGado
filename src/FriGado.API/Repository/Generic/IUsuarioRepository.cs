using FriGado.API.Domain;
using System.Collections.Generic;

namespace FriGado.API.Repository.Generic
{
    public interface IUsuarioRepository<T> : IRepository<T> where T : class
    {
        public Usuario Get(string login);
    }
}
