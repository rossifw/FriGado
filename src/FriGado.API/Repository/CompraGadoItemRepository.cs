using Dapper;
using FriGado.API.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FriGado.API.Repository
{
    public class CompraGadoItemRepository : ICompraGadoItemRepository
    {
        private readonly string connectionString;
        public CompraGadoItemRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public CompraGadoItem GetCompraGadoItem(int id)
        {
            using var conn = new SqlConnection(connectionString);
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

        public IEnumerable<CompraGadoItem> ListAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
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
        }

        public int Add(CompraGadoItem compraGadoItem)
        {            
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("insert into tb_CompraGadoItem values(@IdCompraGado, @IdPecuaristaCompraGado, @IdAnimal, @Quantidade)", new { IdCompraGado = compraGadoItem.CompraGado.Id, IdPecuaristaCompraGado = compraGadoItem.CompraGado.Pecuarista.Id, IdAnimal = compraGadoItem.Animal.Id, Quantidade = compraGadoItem.Quantidade });
            }
        }

        public int Remove(int id)
        {
            throw new NotImplementedException();
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("delete tb_CompraGadoItem where id=@id", new { id = id });
            }
        }

        public int Update(CompraGadoItem compraGadoItem)
        {
            throw new NotImplementedException();
            using (var conn = new SqlConnection(connectionString))
            {
                //return conn.Execute("update tb_CompraGadoItem set IdCompraGado=@IdCompraGado, IdPecuaristaCompraGado=@IdPecuaristaCompraGado, IdAnimal=@IdAnimal, Quantidade=@Quantidade where id=@id", new { Id = compraGadoItem.Id, IdCompraGado = compraGadoItem.Id, IdPecuaristaCompraGado = compraGadoItem.IdPecuaristaCompraGado, IdAnimal = compraGadoItem.IdAnimal, Quantidade = compraGadoItem.Quantidade });
            }
        }
    }
}
