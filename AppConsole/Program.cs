using AppSeriesDio.Entidades;
using AppSeriesDio.Entidades.Enums;
using Repositorio.Repositorio;
using System;

namespace AppConsole
{
	public class Programa
	{
		static RepositorioSerie repositorio = new RepositorioSerie();
		static void Main(string[] args)
		{
			string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
		}

		private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Séries a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries");
			Console.WriteLine("2- Inserir nova série");
			Console.WriteLine("3- Atualizar série");
			Console.WriteLine("4- Excluir série");
			Console.WriteLine("5- Visualizar série");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

		private static void ListarSeries()
		{
			var listarSeries = repositorio.Lista();
			listarSeries.ForEach(p => Console.WriteLine($"{p.Resumo()}\n"));
		}
		private static void InserirSerie()
		{
			Console.WriteLine("Informar Genero (Animais/Documentario): ");
			Genero genero = Enum.Parse<Genero>(Console.ReadLine());
			Console.WriteLine("Informar Título: ");
			string titulo = Console.ReadLine();
			Console.WriteLine("Informar Descrição: ");
			string descricao = Console.ReadLine();
			Console.WriteLine("Informar Ano: ");
			int ano = int.Parse(Console.ReadLine());

			Serie serie = new Serie(repositorio.ProximoId(), genero, titulo, descricao, ano);
			repositorio.Inserir(serie);
		}

		private static void AtualizarSerie()
		{
			Console.WriteLine("Digite o id da serie: ");
			int id = int.Parse(Console.ReadLine());
			var serie = repositorio.RetornaPorId(id);
			Console.WriteLine($"Novo Título ({serie.retornaTitulo()}): ");
			string titulo = Console.ReadLine();
			Console.WriteLine("Novo Genero (Animais/Documentario): ");
			Genero genero = Enum.Parse<Genero>(Console.ReadLine());
			Console.WriteLine("Nova Descrição: ");
			string descricao = Console.ReadLine();
			Console.WriteLine("Novo Ano: ");
			int ano = int.Parse(Console.ReadLine());

			Serie serieAtualizar = new Serie(id, genero, titulo, descricao, ano);
			repositorio.Atualizar(id, serieAtualizar);
		}

		private static void ExcluirSerie()
		{
			Console.WriteLine("Informar id da serie para exclusão: ");
			int id = int.Parse(Console.ReadLine());
			repositorio.Excluir(id);
		}

		private static void VisualizarSerie()
		{
			Console.WriteLine("Informar id da serie que deseja ver: ");
			int id = int.Parse(Console.ReadLine());
            Console.WriteLine(repositorio.RetornaPorId(id).Resumo());
		}


	}
}
