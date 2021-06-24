using CadastroSeries;
using System;
using static System.Console;
using System.Threading;

namespace CadastroSeries
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();

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
                        AtulizaSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Clear();
                        break;
                    default:
                        throw new ArgumentNullException();

                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }

        private static void InserirSerie()

        {
            WriteLine("-----------------------------");
            WriteLine("\nOpção 2 - Inserir Nova Série\n");
            WriteLine("\n=== Generos ===");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Write("-> Informe o Gênero: ");
            int entradaGenero = int.Parse(ReadLine());

            Write("-> Informe o Título da Série: ");
            string entradaTitulo = ReadLine();

            Write("-> Ano de Lançamento da Sério: ");
            int entradaAno = int.Parse(ReadLine());

            Write("-> Descrição da Série: ");
            string entradaDescricao = ReadLine();

            WriteLine("\nInserindo Série....");
            Thread.Sleep(3000);
            WriteLine("Série Inserida Com Sucesso!");

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Insere(novaSerie);

        }

        private static void ExcluirSerie()
        {
            WriteLine("-----------------------------");
            WriteLine("\nOpção 4 - Excluir Série\n");
            WriteLine("\n=== Dados de Exclusão ===");

            Write("Informe o ID da Série Que Deseja Excluir: ");
            int indiceSerie = int.Parse(ReadLine());

            WriteLine("\nExcluíndo...");
            Thread.Sleep(3000);
            WriteLine("Registro Excluído Com Sucesso!");

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            WriteLine("-----------------------------");
            WriteLine("\nOpção 5 - Visualizar Série\n");
            WriteLine("\n=== Visualização ===");

            Write("Informe o ID da Série: ");
            int indiceSerie = int.Parse(ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            WriteLine(serie);

        }

        private static void AtulizaSerie()

        {
            WriteLine("-----------------------------");
            WriteLine("\nOpção 3 - Atalizar Série\n");
            WriteLine("\n=== Dados de Atualização ===");

            Write("\nInforme o ID da Série Desejada: ");
            int indiceSerie = int.Parse(ReadLine());

              
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                WriteLine("{0}.{1}", i, Enum.GetName(typeof(Genero), i));
            }

            Write("\n-> Informe o Gênero: ");
            int entradaGenero = int.Parse(ReadLine());

            Write("-> Informe o Título da Série: ");
            string entradaTitulo = ReadLine();

            Write("-> Ano de Lançamento da Sério: ");
            int entradaAno = int.Parse(ReadLine());

            Write("-> Descrição da Série: ");
            string entradaDescricao = ReadLine();

            WriteLine("\nAtualizando...");
            Thread.Sleep(3000);
            WriteLine("Série Aualizada Com Sucesso!");

            Serie atualizaSerie = new Serie(id: indiceSerie,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao);

            repositorio.Atualiza(indiceSerie, atualizaSerie);

        }

        private static void ListarSeries()
        {

            WriteLine("-----------------------------");
            WriteLine("\n Opção 1 - Listar Séries");
            WriteLine("\n=== Lista de Séries ===");

            WriteLine("\nVerificando Lista de Série...");
            Thread.Sleep(3000);

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                WriteLine("\nALERT: Infelizmente Ainda Não Exite Série Cadastrada.");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.RetornaExluido();

                WriteLine("ID {0}: - {1} - {2}", serie.retornoId(), serie.retornoTitulo(), (excluido ? "Excluido" : ""));
            }
        }




        private static string ObterOpcaoUsuario()
        {
            WriteLine("\n\n-----------------------------");
            WriteLine("Bem-Vindo a Central de Series");
            WriteLine("-----------------------------");
            WriteLine();
            WriteLine("=== Menu de Opções ===");
            WriteLine("1 - Lista Séries");
            WriteLine("2 - Inserir Nova Série");
            WriteLine("3 - Atualizar Série");
            WriteLine("4 - Excluir Série");
            WriteLine("5 - Visualizar Série");
            WriteLine("C - Limpar Tela");
            WriteLine("X - Sair");
            WriteLine("-----------------------------");
            Write("Infome a opção desejada: ");
            string opcaoUsuario = ReadLine().ToUpper();

            return opcaoUsuario;
        }

    }
}
