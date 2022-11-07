using System.Collections.Generic;
using FriGado.API.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using FriGado.API.Repository.Generic;

namespace FriGado.API.Repository
{
    public class PecuaristaRepository : Repository<Pecuarista>, IPecuaristaRepository<Pecuarista>
    {
        public PecuaristaRepository(IConfiguration configuration) : base(configuration) { }

        public override Pecuarista Get(int id)
        {
            using var conn = Connection;
            return conn.QuerySingle<Pecuarista>("select * from tb_pecuarista where id = @id", new { id = id });
        }

        public override IEnumerable<Pecuarista> ListAll()
        {
            using var conn = Connection;
            return conn.Query<Pecuarista>("select * from tb_pecuarista");
        }

        public override int Add(Pecuarista pecuarista)
        {
            using var conn = Connection;
            return conn.Execute("insert into tb_pecuarista values(@nome)", new { nome = pecuarista.Nome });
        }
        public override int Update(Pecuarista pecuarista)
        {
            using var conn = Connection;
            return conn.Execute("update tb_pecuarista set nome=@nome where id=@id", new { nome = pecuarista.Nome, id = pecuarista.Id });
        }

        public override int Remove(int id)
        {
            using var conn = Connection;
            return conn.Execute("delete tb_pecuarista where id=@id", new { id = id });
        }
    }
}
