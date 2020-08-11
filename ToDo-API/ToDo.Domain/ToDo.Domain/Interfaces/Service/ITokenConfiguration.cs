using Microsoft.IdentityModel.Tokens;

namespace ToDo.Domain.Interfaces.Service
{
	public interface ITokenConfiguration
	{
		string Key { get; set; }
		string Audience { get; set; }
		string Issuer { get; set; }
		int LifeTimeSeconds { get; set; }
	}
}
