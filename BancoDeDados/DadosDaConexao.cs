using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EmpresaDeCarros {

	public static class DadosDaConexao {

		private static Configuracao _configuracao;

		static DadosDaConexao() {

			var arquivo = "config.json";

			if (File.Exists(arquivo)) {

				var JsonString = File.ReadAllText(arquivo);

				_configuracao = JsonConvert.DeserializeObject<Configuracao>(JsonString);
			}
		}

		public static string ObterDadosConexao() {

			if (_configuracao == null) {

				throw new InvalidOperationException("Operacao invalida");

			}
			
			return $"Server={_configuracao.Servidor};Port={_configuracao.Porta};Database={_configuracao.BancoDeDados};User={_configuracao.Usuario};Password={_configuracao.Senha}";
		}
	}
	
	public class Configuracao {

		public string Servidor { get; set; }
		public string Porta { get; set; }
		public string BancoDeDados { get; set; }
		public string Usuario { get; set; }
		public string Senha { get; set; }
	}
}