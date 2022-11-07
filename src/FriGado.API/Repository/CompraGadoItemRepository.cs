using Dapper;
using FriGado.API.Domain;
using FriGado.API.Repository.Generic;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace FriGado.API.Repository
{
    public class CompraGadoItemRepository : Repository<CompraGadoItem>, ICompraGadoItemRepository<CompraGadoItem>
    {
        public CompraGadoItemRepository(IConfiguration configuration) : base(configuration) { }

        public override CompraGadoItem Get(int id)
        {
            using var conn = Connection;
            var query = @"select * from Tb_CompraGadoItem i
                          inner join Tb_CompraGado c on c.id=i.IdCompraGado and c.IdPecuarista=i.IdPecuaristaCompraGado
                          inner join Tb_Animal a on a.Id = i.IdAnimal
                          where i.id = @id";
            return conn.Query<CompraGadoItem, CompraGado, Animal, CompraGadoItem>(query,
                param: new { id = id },
                map: (compraGadoItem, compraGado, animal) =>
                {
                    compraGadoItem.CompraGado = compraGado;
                    compraGadoItem.Animal = animal;
                    return compraGadoItem;
                }).First();
        }

        public override IEnumerable<CompraGadoItem> ListAll()
        {
            using var conn = Connection;

            var query = @"select * from Tb_CompraGadoItem i
                              inner join Tb_CompraGado c on c.id=i.IdCompraGado and c.IdPecuarista=i.IdPecuaristaCompraGado
                              inner join Tb_Pecuarista p on p.id=c.idPecuarista
                              inner join Tb_Animal a on a.Id = i.IdAnimal";
            var o = conn.Query<CompraGadoItem, CompraGado, Pecuarista, Animal, CompraGadoItem>(query,
                map: (compraGadoItem, compraGado, pecuarista, animal) =>
                {
                    compraGado.Pecuarista = pecuarista;
                    compraGadoItem.CompraGado = compraGado;
                    compraGadoItem.Animal = animal;
                    return compraGadoItem;
                },
                splitOn: ("id, id, id"));
            return o;

        }

        public override int Add(CompraGadoItem compraGadoItem)
        {
            using var conn = Connection;
            return conn.Execute("insert into tb_CompraGadoItem values(@IdCompraGado, @IdPecuaristaCompraGado, @IdAnimal, @Quantidade)", new { IdCompraGado = compraGadoItem.CompraGado.Id, IdPecuaristaCompraGado = compraGadoItem.CompraGado.Pecuarista.Id, IdAnimal = compraGadoItem.Animal.Id, Quantidade = compraGadoItem.Quantidade });
        }

        public override int Remove(int id)
        {
            using var conn = Connection;
            return conn.Execute("delete tb_CompraGadoItem where id=@id", new { id = id });
        }

        public override int Update(CompraGadoItem compraGadoItem)
        {
            using var conn = Connection;
            return conn.Execute("update tb_CompraGadoItem set IdCompraGado=@IdCompraGado, IdPecuaristaCompraGado=@IdPecuaristaCompraGado, IdAnimal=@IdAnimal, Quantidade=@Quantidade where id=@id", new { Id = compraGadoItem.Id, IdCompraGado = compraGadoItem.CompraGado.Id, IdPecuaristaCompraGado = compraGadoItem.CompraGado.Pecuarista.Id, IdAnimal = compraGadoItem.Animal.Id, Quantidade = compraGadoItem.Quantidade });
        }
    }
}
