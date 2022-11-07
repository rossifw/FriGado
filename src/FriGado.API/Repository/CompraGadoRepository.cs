using Dapper;
using FriGado.API.Domain;
using FriGado.API.Repository.Generic;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace FriGado.API.Repository
{
    public class CompraGadoRepository : Repository<CompraGado>, ICompraGadoRepository<CompraGado>
    {
        public CompraGadoRepository(IConfiguration configuration) : base(configuration) { }

        public override CompraGado Get(int id)
        {
            using var conn = Connection;
            return conn.Query<CompraGado, Pecuarista, CompraGado>("select * from Tb_CompraGado c inner join Tb_Pecuarista p on p.id = c.IdPecuarista where c.id = @id",
                param: new { id = id },
                map: (compraGado, pecuarista) =>
                {
                    compraGado.Pecuarista = pecuarista;
                    return compraGado;
                }).First();
        }

        public override IEnumerable<CompraGado> ListAll()
        {
            using var conn = Connection;
            return conn.Query<CompraGado, Pecuarista, CompraGado>("select * from Tb_CompraGado c inner join Tb_Pecuarista p on p.id = c.IdPecuarista",
                map: (compraGado, pecuarista) =>
                {
                    compraGado.Pecuarista = pecuarista;
                    return compraGado;
                });
        }

        public override int Add(CompraGado compraGado)
        {
            using var conn = Connection;
            return conn.Execute("insert into Tb_CompraGado values(@IdPecuarista, @DataEntrega)", new { IdPecuarista = compraGado.Pecuarista.Id, DataEntrega = compraGado.DataEntrega });
        }
        public override int Update(CompraGado compraGado)
        {
            using var conn = Connection;
            return conn.Execute("update Tb_CompraGado set IdPecuarista=@IdPecuarista, DataEntrega=@DataEntrega where id=@id", new { Id = compraGado.Id, IdPecuarista = compraGado.Pecuarista.Id, DataEntrega = compraGado.DataEntrega });
        }

        public override int Remove(int id)
        {
            using var conn = Connection;
            return conn.Execute("delete Tb_CompraGado where id=@id", new { id = id });
        }
    }
}
