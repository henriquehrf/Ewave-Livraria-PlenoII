using System;
using System.Collections.Generic;
using System.Text;

namespace ToDo.Domain.Models
{
	public class EmprestimoModel
	{
		public int Id { get; set; }
		public int IdUsuario { get; set; }
		public int IdLivro { get; set; }
		public DateTime? DataDevolucao { get; set; }
		public DateTime DataEmprestimo { get; set; }
		public int Status { get; set; }
	}
}
