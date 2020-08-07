using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Cpf
	{
		public Contract Contract { get; }
		private readonly string _valor;

		private Cpf(string value)
		{
			_valor = value;
			Contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Cpf(string value) => new Cpf(value);

		private bool Validar()
		{
			if (string.IsNullOrWhiteSpace(_valor))
				return AdicionarNotificacao("Obrigatório informar um CPF.");

			if (_valor.Length != 11)
				return AdicionarNotificacao("Um CPF valido deve conter 11 caracteres.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			Contract.AddNotification(nameof(Cpf), mensagem);
			return false;
		}
	}
}
