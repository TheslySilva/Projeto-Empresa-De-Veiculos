using System;
using System.Linq;
using MySqlConnector;

namespace EmpresaDeCarros;

public enum Opcoes {

	LerDados,
	VerificarUsuario,
	VerificarVeiculo
}

public static class Conexao {

	private static MySqlConnection iniciarConexao() {

		MySqlConnection conexao = new MySqlConnection(DadosDaConexao.ObterDadosConexao());
		conexao.Open();

		return conexao;
	}

	// PegarDados
	public static void PegarDados(Opcoes opcao) {

		string comando = "SELECT * FROM Estoque;";

		using (MySqlCommand cmd = new MySqlCommand(comando, iniciarConexao())) {

			try {
				using (MySqlDataReader leitura = cmd.ExecuteReader()) {

					switch (opcao) {

						case Opcoes.LerDados:
							Leitura.LerDados(leitura);
							break;
						case Opcoes.VerificarUsuario:
						break;
					}
				}
			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
	}

	// Enviar Dados
	public static void EnviarDados(string modelo, string marca, double valor) {

		string comando = $"INSERT INTO Estoque(Modelo,Marca,Valor) VALUE ('{modelo}','{marca}','{valor}');";

		using (MySqlCommand cmd = new MySqlCommand(comando, iniciarConexao())) {

			try {

				int leitura = cmd.ExecuteNonQuery();

				if (leitura > 0) {
					Console.WriteLine("Enviado com Sucesso!");
				} else {
					Console.WriteLine("Falha ao Enviar");
				}

			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
	}

	// Deletar Dados
	public static void DeletarDados(string modelo, string marca) {

		string comando = $"DELETE FROM Veiculos WHERE Modelo ='{modelo}'AND Marca = '{marca}';";

		using (MySqlCommand cmd = new MySqlCommand(comando, iniciarConexao())) {

			try {

				int leitura = cmd.ExecuteNonQuery();

				if (leitura > 0) {
					Console.WriteLine("Deletado com Sucesso!");
				} else {
					Console.WriteLine("Falha ao Deletar!");
				}

			} catch (Exception ex) {
				Console.WriteLine(ex.Message);
			}
		}
	}
}