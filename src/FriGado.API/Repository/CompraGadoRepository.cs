using Dapper;
using FriGado.API.Domain;
using FriGado.API.Repository.Generic;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FriGado.API.Repository
{
    public class CompraGadoRepository : ICompraGadoRepository<CompraGado>
    {
        private readonly string connectionString;
        public CompraGadoRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public CompraGado Get(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Query<CompraGado, Pecuarista, CompraGado>("select * from Tb_CompraGado c inner join Tb_Pecuarista p on p.id = c.IdPecuarista where c.id = @id",
                param: new { id = id },
                map: (compraGado, pecuarista) =>
                {
                    compraGado.Pecuarista = pecuarista;
                    return compraGado;
                }).First();
        }

        public IEnumerable<CompraGado> ListAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<CompraGado, Pecuarista, CompraGado>("select * from Tb_CompraGado c inner join Tb_Pecuarista p on p.id = c.IdPecuarista",
                    map: (compraGado, pecuarista) =>
                    {
                        compraGado.Pecuarista = pecuarista;
                        return compraGado;
                    });
            }
        }

        public int Add(CompraGado compraGado)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("insert into Tb_CompraGado values(@IdPecuarista, @DataEntrega)", new { IdPecuarista = compraGado.Pecuarista.Id, DataEntrega = compraGado.DataEntrega });
            }
        }
        public int Update(CompraGado compraGado)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("update Tb_CompraGado set IdPecuarista=@IdPecuarista, DataEntrega=@DataEntrega where id=@id", new { Id = compraGado.Id, IdPecuarista = compraGado.Pecuarista.Id, DataEntrega = compraGado.DataEntrega });
            }
        }

        public int Remove(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("delete Tb_CompraGado where id=@id", new { id = id });
            }
        }
    }
}
