using System;
using System.Linq;
using MySqlConnector;
using System.Collections.Generic;

namespace EmpresaDeCarros;

public static class Leitura {

	public static void LerDados(MySqlDataReader leitura) {

		while (leitura.Read()) {

			int Id = leitura.GetInt32("ID");
			string Modelo = leitura.GetString("Modelo");
			string Marca = leitura.GetString("Marca");
			int Valor = leitura.GetInt32("Valor");

			Console.WriteLine($"ID: {Id} | Modelo: {Modelo} | Marca: {Marca} | Valor: {Valor}");
		}

	}
}
