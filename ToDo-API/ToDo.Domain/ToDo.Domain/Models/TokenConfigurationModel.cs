namespace ToDo.Domain.Models
{
	public class TokenConfigurationModel
	{
		public string Audience { get; set; }
		public string Issuer { get; set; }
		public int TempoEmSegundos { get; set; }
	}
}
