using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Cnpj
	{
		private readonly string _valor;
		public readonly Contract _contract;

		private Cnpj(string value)
		{
			_valor = value;
			_contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Cnpj(string value) => new Cnpj(value);

		private bool Validar()
		{
			if (string.IsNullOrWhiteSpace(_valor))
				return AdicionarNotificacao("Obrigatório informar um CNPJ.");

			if (_valor.Length != 18)
				return AdicionarNotificacao("Um CNPJ valido deve conter 18 caracteres.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			_contract.AddNotification(nameof(Cnpj), mensagem);
			return false;
		}
	}
}
