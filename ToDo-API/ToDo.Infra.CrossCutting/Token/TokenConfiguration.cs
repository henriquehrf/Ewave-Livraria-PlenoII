using ToDo.Domain.Interfaces.Service;

namespace ToDo.Domain.Models
{
	public class TokenConfiguration : ITokenConfiguration
	{
		public string Key { get; set; }
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public int LifeTimeSeconds { get; set; }
	}
}
