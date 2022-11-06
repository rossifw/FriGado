using Dapper;
using FriGado.API.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace FriGado.API.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string connectionString;
        public UsuarioRepository(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }        

        public Usuario GetUsuario(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.QuerySingle<Usuario>("select * from tb_usuario where id = @id", new { id = id });
        }

        public Usuario GetUsuario(string login)
        {
            using var conn = new SqlConnection(connectionString);
            return conn.Query<Usuario>("select * from tb_usuario where login = @login", new { login = login }).SingleOrDefault();
        }

        public IEnumerable<Usuario> ListAll()
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Query<Usuario>("select * from tb_usuario");
            }
        }

        public int Add(Usuario usuario)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("insert into tb_usuario values(@login, @nome, @senha)", new { login = usuario.Login, nome = usuario.Nome, senha=usuario.Senha });
            }
        }

        public int Remove(int id)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("delete tb_usuario where id=@id", new { id = id });
            }
        }

        public int Update(Usuario usuario)
        {            
            using (var conn = new SqlConnection(connectionString))
            {
                return conn.Execute("update tb_usuario set login=@login, nome=@nome, senha=@senha where id=@id", new { id=usuario.Id, login = usuario.Login, nome = usuario.Nome, senha = usuario.Senha });
            }
        }        
    }
}
