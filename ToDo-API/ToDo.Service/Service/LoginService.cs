using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;

namespace ToDo.Service.Service
{
	public class LoginService : ILoginService
	{
		private readonly IUsuarioService _usuarioService;
		private readonly ITokenConfiguration _tokenConfiguration;

		public LoginService(IUsuarioService usuarioService, ITokenConfiguration tokenConfiguration)
		{
			_usuarioService = usuarioService;
			_tokenConfiguration = tokenConfiguration;
		}

		public object EfetuarLogin(CredenciaisModel credenciais)
		{
			var usuarioBase = _usuarioService.UsuarioPorLogin(credenciais.Usuario);

			if (!CredencialEhValida(credenciais, usuarioBase))
			{
				return new
				{
					authenticated = false,
					message = "Usuário inválido!"
				};
			}

			ClaimsIdentity identity = new ClaimsIdentity(
				new GenericIdentity(credenciais.Usuario, "Login"),
				new[] {
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
						new Claim("id", usuarioBase.Id.ToString()),
						new Claim("nome", usuarioBase.Nome),
						new Claim("perfil", usuarioBase.TipoUsuarioDescricao),
				}
			);

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.Key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var issuer = _tokenConfiguration.Issuer;
			var audience = _tokenConfiguration.Audience;

			var dataHoraExpiracao = RetornarDataExpiracaoToken(_tokenConfiguration.LifeTimeSeconds);
			var handler = new JwtSecurityTokenHandler();
			var securityToken = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = issuer,
				Audience = audience,
				SigningCredentials = credentials,
				Subject = identity,
				NotBefore = DateTime.Now,
				Expires = dataHoraExpiracao

			});
			var token = handler.WriteToken(securityToken);
			return new
			{
				authenticated = true,
				created = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
				expiration = dataHoraExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
				accessToken = token,
				message = "OK"
			};

		}

		private DateTime RetornarDataExpiracaoToken(int tempoEmSegundos)
		{
			return DateTime.Now + TimeSpan.FromSeconds(tempoEmSegundos);
		}

		private bool CredencialEhValida(CredenciaisModel credenciais, UsuarioModel usuarioBase)
		{
			if (credenciais == null || string.IsNullOrWhiteSpace(credenciais.Usuario))
				return false;

			return (usuarioBase != null &&
					credenciais.Usuario == usuarioBase.Login &&
					credenciais.Senha == usuarioBase.Senha);
		}
	}
}
