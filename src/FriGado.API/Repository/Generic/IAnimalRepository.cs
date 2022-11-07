using FriGado.API.Domain;
using System.Collections.Generic;

namespace FriGado.API.Repository.Generic
{
    public interface IAnimalRepository<T> : IRepository<T> where T : class
    {

    }
}
