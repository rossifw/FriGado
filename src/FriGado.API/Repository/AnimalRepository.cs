using Dapper;
using FriGado.API.Domain;
using FriGado.API.Repository.Generic;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FriGado.API.Repository
{
    public class AnimalRepository : IAnimalRepository<Animal>
    {
        private readonly string connectionString;
        public AnimalRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public Animal Get(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.QuerySingle<Animal>("select * from tb_animal where id = @id", new { id = id });
        }

        public IEnumerable<Animal> ListAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Animal>("select * from tb_animal");
            }
        }

        public int Add(Animal animal)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("insert into tb_animal values(@desc, @preco)", new { desc = animal.Descricao, preco = animal.Preco });
            }
        }
        public int Update(Animal animal)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("update tb_animal set Descricao=@desc, Preco=@preco where id=@id", new { desc = animal.Descricao, preco = animal.Preco, id = animal.Id });
            }
        }

        public int Remove(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("delete tb_animal where id=@id", new { id = id });
            }
        }
    }
}
