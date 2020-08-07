using Microsoft.IdentityModel.Tokens;

namespace ToDo.Domain.Interfaces.Service
{
	public interface IToken
	{
		 SecurityKey Key { get; }
		 SigningCredentials Credentials { get; }
	}
}
