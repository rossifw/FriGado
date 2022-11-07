using Dapper;
using FriGado.API.Domain;
using FriGado.API.Repository.Generic;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace FriGado.API.Repository
{
    //public class AnimalRepository : IAnimalRepository<Animal>
    public class AnimalRepository : Repository<Animal>, IAnimalRepository<Animal>
    {
        public AnimalRepository(IConfiguration configuration) : base(configuration) { }

        public override Animal Get(int id)
        {
            using var conn = Connection;
            return conn.QuerySingle<Animal>("select * from tb_animal where id = @id", new { id = id });
        }

        public override IEnumerable<Animal> ListAll()
        {
            using var conn = Connection;
            return conn.Query<Animal>("select * from tb_animal");
        }

        public override int Add(Animal animal)
        {
            using var conn = Connection;
            return conn.Execute("insert into tb_animal values(@desc, @preco)", new { desc = animal.Descricao, preco = animal.Preco });
        }
        public override int Update(Animal animal)
        {
            using var conn = Connection;
            return conn.Execute("update tb_animal set Descricao=@desc, Preco=@preco where id=@id", new { desc = animal.Descricao, preco = animal.Preco, id = animal.Id });
        }

        public override int Remove(int id)
        {
            using var conn = Connection;
            return conn.Execute("delete tb_animal where id=@id", new { id = id });
        }
    }
}
