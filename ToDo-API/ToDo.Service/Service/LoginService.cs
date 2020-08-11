using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using ToDo.Domain.Interfaces.Service;
using ToDo.Domain.Models;

namespace ToDo.Service.Service
{
	public class LoginService : ILoginService
	{
		private readonly IUsuarioService _usuarioService;
		private readonly IToken _tokenService;

		public LoginService(IUsuarioService usuarioService, IToken tokenService)
		{
			_usuarioService = usuarioService;
			_tokenService = tokenService;
		}

		public object EfetuarLogin(CredenciaisModel credenciais, TokenConfigurationModel tokenConfigurationModel)
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
			;

			var dataHoraExpiracao = RetornarDataExpiracaoToken(tokenConfigurationModel.TempoEmSegundos);
			var handler = new JwtSecurityTokenHandler();
			var securityToken = handler.CreateToken(new SecurityTokenDescriptor
			{
				Issuer = tokenConfigurationModel.Issuer,
				Audience = tokenConfigurationModel.Audience,
				SigningCredentials = _tokenService.Credentials,
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
