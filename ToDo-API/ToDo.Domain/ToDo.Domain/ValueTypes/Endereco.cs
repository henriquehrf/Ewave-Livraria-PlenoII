using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Endereco
	{
		private readonly string _valor;
		public readonly Contract _contract;

		private Endereco(string value)
		{
			_valor = value;
			_contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Endereco(string value) => new Endereco(value);

		private bool Validar()
		{
			if (string.IsNullOrWhiteSpace(_valor))
				return AdicionarNotificacao("Obrigatório informar um endereço.");

			if (_valor.Length < 10)
				return AdicionarNotificacao("Um endereço não pode ter menos que 10 caracteres.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			_contract.AddNotification(nameof(Endereco), mensagem);
			return false;
		}
	}
}
