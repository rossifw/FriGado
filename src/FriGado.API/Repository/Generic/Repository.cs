using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FriGado.API.Repository.Generic
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private string _connectionString { get; }

        protected SqlConnection Connection => new SqlConnection(_connectionString);

        public Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public abstract int Add(T obj);
        public abstract T Get(int id);
        public abstract IEnumerable<T> ListAll();
        public abstract int Remove(int id);
        public abstract int Update(T obj);
    }
}
