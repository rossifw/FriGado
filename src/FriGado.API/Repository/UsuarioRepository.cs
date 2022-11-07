using Dapper;
using FriGado.API.Domain;
using FriGado.API.Repository.Generic;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FriGado.API.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository<Usuario>
    {
        public UsuarioRepository(IConfiguration configuration) : base(configuration) { }

        public override Usuario Get(int id)
        {
            using var conn = Connection;
            return conn.QuerySingle<Usuario>("select * from tb_usuario where id = @id", new { id = id });
        }

        public Usuario Get(string login)
        {
            using var conn = Connection;
            return conn.Query<Usuario>("select * from tb_usuario where login = @login", new { login = login }).SingleOrDefault();
        }

        public override IEnumerable<Usuario> ListAll()
        {
            using var conn = Connection;
            return conn.Query<Usuario>("select * from tb_usuario");
        }

        public override int Add(Usuario usuario)
        {
            using var conn = Connection;
            return conn.Execute("insert into tb_usuario values(@login, @nome, @senha)", new { login = usuario.Login, nome = usuario.Nome, senha = usuario.Senha });
        }

        public override int Remove(int id)
        {
            using var conn = Connection;
            return conn.Execute("delete tb_usuario where id=@id", new { id = id });
        }

        public override int Update(Usuario usuario)
        {
            using var conn = Connection;
            return conn.Execute("update tb_usuario set login=@login, nome=@nome, senha=@senha where id=@id", new { id = usuario.Id, login = usuario.Login, nome = usuario.Nome, senha = usuario.Senha });
        }
    }
}
