using System;
using DIO.Series.Classes;
using static System.Console;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            //Séries
            string opcaoSerie = OpcaoSerieUsuario();

            while (opcaoSerie.ToUpper() != "X")
            {
                switch (opcaoSerie)
                {
                    case "1":
                        ListarSerie();
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
                        Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoSerie = OpcaoSerieUsuario();
            }
            WriteLine("Obrigado por utilizar nossos serviços!");
            ReadLine();
        }

        //visuliza serie
        private static void VisualizarSerie()
        {
            WriteLine("Digite o id da série que gostaria de visualizar: ");
            int indiceSerie = int.Parse(ReadLine());

            var serie = repositorio.RetornaId(indiceSerie);
            WriteLine(serie);
        }

        //exclui serie
        private static void ExcluirSerie()
        {
            WriteLine("Digite o id da série ao qual deseja excluir: ");
            int indiceSerie = int.Parse(ReadLine());

            repositorio.Excluir(indiceSerie);

        }

        //atualiza serie
        private static void AtualizarSerie()
        {
            WriteLine("Inserir nova série");
            int indiceSerie = int.Parse(ReadLine());

            foreach (int i in Enum.GetValues(typeof(Genero)))         
                WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));  

            //Genero
            WriteLine("Digite o gênero entre as opções listadas acima: ");
            int entradaGenero = int.Parse(ReadLine());

            //Titulo
            WriteLine("Digite o título da série: ");
            string entradaTitulo = ReadLine();

            //Descricao
            WriteLine("Digite a descrição da série: ");
            string entradaDescricao = ReadLine();

            //Ano
            WriteLine("Digite o ano da série: ");
            int entradaAno = int.Parse(ReadLine());

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao
                                            );
            repositorio.Atualizar(indiceSerie, atualizarSerie);
        }

        // listar series
        private static void ListarSerie()
        {
            WriteLine("Listar série");

            var listaSerie = repositorio.ListaSerie();

            if (listaSerie.Count == 0)
            {
                WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in listaSerie)
            {
                var excluido = serie.retornaExcluido();

                WriteLine("#ID {0} : - {1}  {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluido*" : ""));
            }
        }

        // inserir nova serie
        private static void InserirSerie()
        {
            WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
                WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));          

            //Genero
            WriteLine("Digite o gênero entre as opções listadas acima: ");
            int entradaGenero = int.Parse(ReadLine());

            //Titulo
            WriteLine("Digite o título da série: ");
            string entradaTitulo = ReadLine();

            //Descricao
            WriteLine("Digite a descrição da série: ");
            string entradaDescricao = ReadLine();

            //Ano
            WriteLine("Digite o ano da série: ");
            int entradaAno = int.Parse(ReadLine());

            //inserindo nova serie
            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao
                                        );
            repositorio.Inserir(novaSerie);
        }

        //opcao do usuario
        private static string OpcaoSerieUsuario()
        {
            WriteLine();
            WriteLine("DIO Séries e Fimes ao seu dispor");
            WriteLine("Informe a opção desejada: ");

            WriteLine("1 - Lista séries");
            WriteLine("2 - Inserir nova série");
            WriteLine("3 - Atualizar série");
            WriteLine("4 - Excluir série");
            WriteLine("5 - Visualizar série");
            WriteLine("6 - Limpar Tela");
            WriteLine("X - Sair");

            string opcaoSerie = ReadLine().ToUpper();
            WriteLine();
            return opcaoSerie;

        }
    }
}
