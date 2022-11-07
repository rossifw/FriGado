using FriGado.API.Domain;
using FriGado.API.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System;

namespace FriGado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository usuario;

        public LoginController(IUsuarioRepository usuario)
        {
            this.usuario = usuario;
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Usuario usuario
                                 , [FromServices] SigningConfigurations signingConfigurations
                                 , [FromServices] TokenConfigurations tokenConfigurations)
        {
            var isCredencialValida = false;
            Usuario usuarioValido = null;

            if (usuario != null && !string.IsNullOrEmpty(usuario.Login))
            {
                usuarioValido = this.usuario.GetUsuario(usuario.Login);
                isCredencialValida = usuario.Senha.Equals(usuarioValido?.Senha);
            }

            if (isCredencialValida)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuarioValido.Login, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuarioValido.Nome),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return Ok(new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                });
            }
            else
            {
                return Ok(new
                {
                    authenticated = false,
                    message = "Credencial inválida!"
                });
            }
        }

    }
}
