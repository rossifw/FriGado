using System;
using System.Collections.Generic;
using FriGado.API.Domain;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using FriGado.API.Repository.Generic;

namespace FriGado.API.Repository
{
    public class PecuaristaRepository : IPecuaristaRepository<Pecuarista>
    {
        private readonly string connectionString;
        public PecuaristaRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }        

        public Pecuarista Get(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.QuerySingle<Pecuarista>("select * from tb_pecuarista where id = @id", new { id = id });
        }

        public IEnumerable<Pecuarista> ListAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Pecuarista>("select * from tb_pecuarista");
            }
        }

        public int Add(Pecuarista pecuarista)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("insert into tb_pecuarista values(@nome)", new { nome = pecuarista.Nome });
            }
        }
        public int Update(Pecuarista pecuarista)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("update tb_pecuarista set nome=@nome where id=@id", new { nome = pecuarista.Nome, id = pecuarista.Id });
            }
        }

        public int Remove(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("delete tb_pecuarista where id=@id", new { id = id });
            }
        }
    }
}
