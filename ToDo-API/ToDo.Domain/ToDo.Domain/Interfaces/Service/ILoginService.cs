using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces.Service
{
	public interface ILoginService
	{
		object EfetuarLogin(CredenciaisModel credenciais, TokenConfigurationModel tokenConfigurationModel);
	}
}
