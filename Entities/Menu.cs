using System;
using System.Linq;
using System.Collections.Generic;

namespace EmpresaDeCarros;

public class Menu {

	public static void Apresentacao() {

		Console.Write("Bem Vindos a ");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.Write("NexDriver Motors!\n");
		Console.ResetColor();
		
		Console.WriteLine("\nDescubra a emoção de dirigir em grande estilo com nossa coleção exclusiva.");
		
		Console.WriteLine("\n"+ new String('-',51));
		
		Console.Write("\nJá possue uma conta na ");
		Console.ForegroundColor = ConsoleColor.Yellow;
		Console.Write("NexDriver? ");
		Console.ResetColor();
		
		char status = char.Parse(Console.ReadLine());
		
		Console.WriteLine("");
	}
}
