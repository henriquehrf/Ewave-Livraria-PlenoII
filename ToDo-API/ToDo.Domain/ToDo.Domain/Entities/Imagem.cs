namespace ToDo.Domain.Entities
{
	public class Imagem : BaseEntity<int>
	{
		public string Nome { get; }
		public byte[] Dados { get; }
		public string ContentType { get; }
	}
}
