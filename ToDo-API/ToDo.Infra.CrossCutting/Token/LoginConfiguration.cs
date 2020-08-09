using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using ToDo.Domain.Interfaces.Service;

namespace ToDo.Infra.CrossCutting.Token
{
	public class LoginConfiguration: IToken
	{
		public SecurityKey Key { get; }
		public SigningCredentials Credentials { get; }

		public LoginConfiguration()
		{
			using var provider = new RSACryptoServiceProvider(2048);
			Key = new RsaSecurityKey(provider.ExportParameters(true));

			Credentials = new SigningCredentials(
				Key, SecurityAlgorithms.RsaSha256);
		}
	}
}

