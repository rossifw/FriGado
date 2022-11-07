using System;
using System.Collections.Generic;

namespace FriGado.API.Repository.Generic
{
    public interface IRepository<T> where T : class
    {
        public T Get(int id);
        public IEnumerable<T> ListAll();

        public int Add(T obj);
        public int Update(T obj);
        public int Remove(int id);
    }
}
