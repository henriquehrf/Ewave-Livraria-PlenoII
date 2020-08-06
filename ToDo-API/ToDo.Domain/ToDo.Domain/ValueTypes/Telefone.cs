using Flunt.Validations;
using System.Text.RegularExpressions;

namespace ToDo.Domain.ValueTypes
{
	public struct Telefone
	{
		private readonly string _valor;
		public readonly Contract _contract;

		private Telefone(string value)
		{
			_valor = value;
			_contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Telefone(string value) => new Telefone(value);

		private bool Validar()
		{
			if (!string.IsNullOrEmpty(_valor) && !Regex.IsMatch(_valor, (@"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$")))
				return AdicionarNotificacao("Formato de telefone inválido!");


			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			_contract.AddNotification(nameof(Telefone), mensagem);
			return false;
		}
	}
}
