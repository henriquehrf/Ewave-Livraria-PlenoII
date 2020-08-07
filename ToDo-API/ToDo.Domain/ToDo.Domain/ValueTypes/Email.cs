using Flunt.Validations;

namespace ToDo.Domain.ValueTypes
{
	public struct Email
	{
		public Contract Contract { get; }
		private readonly string _valor;

		private Email(string value)
		{
			_valor = value;
			Contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Email(string value) => new Email(value);

		private bool Validar()
		{
			if (string.IsNullOrEmpty(_valor))
				return true;

			bool ehUmFinalValido = (_valor.EndsWith(".com") || _valor.EndsWith(".com.br"));
			bool contemArroba = _valor.Contains("@");

			if (!contemArroba && !ehUmFinalValido)
				return AdicionarNotificacao("Formato de email inválido!");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			Contract.AddNotification(nameof(Email), mensagem);
			return false;
		}
	}
}
