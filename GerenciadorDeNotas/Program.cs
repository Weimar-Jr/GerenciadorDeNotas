using System;
using System.Collections.Generic;
using System.Threading.Tasks.Dataflow;

namespace GerenciadorDeNotas
{

    class CriarNota
    {
        //campos
        private string titulo;
        private string nota;

        //propriedades
        public string Titulo { get; set; }
        public string Nota { get; set; }

        //metodo de alterar nota 
        public void AlterarNota()
        {
            //texto do subMenu de editar nota
            Console.WriteLine("Digite a opção que você deseja serguir");
            Console.WriteLine("1 - Para mudar o titulo.");
            Console.WriteLine("2 - Para mudar a descrição.");
            Console.WriteLine("3 - Para sair.");

            //seleção de opção e opções de edição
            int resposta = Convert.ToInt32(Console.ReadLine());
            if( resposta == 1)
            {
                //titulo antigo e entranda de novo titulo
                Console.WriteLine($"Titulo antigo: \n{this.Titulo}");
                Console.WriteLine("Digite o novo titulo:");
                string resposta2 = Console.ReadLine();
                Console.WriteLine($"Aqui esta o novo titulo:\n{resposta2}\nEle esta certo? s/n");
                string resposta3 = Console.ReadLine();
                //if para sobrescrever o titulo se estiver certo
                if (resposta3 == "s" || resposta3 == "S")
                {
                    Console.WriteLine("Titulo alterado com sucesso");
                    this.Titulo = resposta3;
                }
                else if(resposta3 == "n" || resposta3 == "N")
                {
                    AlterarNota();
                }
                else
                {
                    Console.WriteLine("Opção invalida");
                }
            }
            else if(resposta == 2)
            {
                // nota antiga e entrada de nova nota
                Console.WriteLine($"Nota antiga:\n {this.Nota}");
                Console.WriteLine("Digite a nova nota:");
                string resposta2 = Console.ReadLine();
                Console.WriteLine($"Aqui esta a nova nota:\n{resposta2}\nEla esta certo? s/n");
                string resposta3 = Console.ReadLine();
                //if para sobrescrever o titulo se estiver certo
                if (resposta3 == "s" || resposta3 == "S")
                {
                    Console.WriteLine("Nota alterada com sucesso");
                    this.Nota = resposta3;
                }
                else if (resposta3 == "n" || resposta3 == "N")
                {
                    AlterarNota();
                }
                else
                {
                    Console.WriteLine("Opção invalida");
                }
            }
            else if( resposta == 3)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("Opção invalida");
                AlterarNota();
            }
        }
        // metodo de mostrar a nota
        public void MostrarNota()
        {
            Console.WriteLine($"Titulo:\n{this.Titulo}\nNota:\n{this.Nota}");
        }
      
        //construtor
        public CriarNota(string titulo, string nota)
        {
            this.Titulo = titulo;
            this.Nota = nota;
        }

    }

    class Program
    {
        //lista
        public static List<CriarNota> notas = new List<CriarNota>();


        //metodo main
        static void Main(string[] args)
        {
    
            //Menu principal
            int resposta = 0;
            do
            {
                try
                {
                    Console.WriteLine("Bem vindo, digite a opção que deseja seguir");
                    Console.WriteLine("1 - Adicionar uma nova nota");
                    Console.WriteLine("2 - Alterar uma nota");
                    Console.WriteLine("3 - Exibir as notas");
                    Console.WriteLine("4 - Exluir uma nota");
                    Console.WriteLine("5 - Sair");
                    resposta = Convert.ToInt32(Console.ReadLine());
                    switch (resposta)
                    {
                        case 1:
                            AdicionarNota();
                            break;
                        case 2:
                            AlterarNota();
                            break;
                        case 3:
                            VisualizarNotas();
                            break;
                        case 4:
                            ExcluirNota();
                            break;
                        case 5:
                            resposta = 5;
                            break;
                    }
                
                }
                catch (FormatException)
                {
                    Console.WriteLine("Por favor digite apenas numeros.");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }

            } while (resposta != 5);

            
        }

        //metodo adicionar nota
        static void AdicionarNota()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o Titulo da nota: ");
                string titulo = Console.ReadLine();

                Console.Clear();

                Console.WriteLine("Digite a nota: ");
                string nota = Console.ReadLine();
                Console.Clear();
                Console.WriteLine($"Aqui está o titulo e a nota.\nTitulo:\n{titulo}\nNota:\n{nota}.");
                Console.WriteLine("Esta tudo certo? s/n");
                string resposta = Console.ReadLine();
                if (resposta == "s" || resposta == "S")
                {
                    CriarNota notaCompleta = new CriarNota(titulo, nota);
                    notas.Add(notaCompleta);
                    Console.Clear();
                    Console.WriteLine("Nota adionada com sucesso");

                }
                else if (resposta == "n" || resposta == "N")
                {
                    Console.WriteLine("Deseja sair? se sim, digite \"sair\", se deseja voltar para o opção de adicionar notas, digite qualquer coisa");
                    string resposta2 = Console.ReadLine();
                    if (resposta2 == "sair" || resposta2 == "Sair" || resposta2 == "SAIR")
                    {
                        AdicionarNota();
                    }
                }
                else
                {
                    Console.WriteLine("Opcção errada. tente de novo");
                    AdicionarNota();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
                 
        }
        static void AlterarNota()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o titulo da nota que você deseja alterar: ");
                String nome = Console.ReadLine();

                //Controle de conteudo
                if (nome != string.Empty)
                {
                    //tentando usar linq
                    var notaEspecifica = notas.FirstOrDefault(n => n.Titulo == nome);


                    if (notaEspecifica != null)
                    {
                        Console.Clear();
                        Console.WriteLine(" A nota foi achada, caso n deseja alterar alguma das opções, pule apertando \"enter\"");
                        Console.WriteLine("Digte o novo titulo");
                        string novoTitulo = Console.ReadLine();
                        //checando se não esta vazio
                        if (novoTitulo != string.Empty)
                        {
                            Console.Clear();
                            Console.WriteLine($"Este é o novo titulo: {novoTitulo}\nEsta certo? s/n");
                            string resposta = Console.ReadLine();
                            if (resposta == "s" || resposta == "S")
                            {
                                Console.Clear();
                                Console.WriteLine("Foi atualizado o titulo");

                                notaEspecifica.Titulo = novoTitulo;
                                //alteração da nota
                                Console.WriteLine("Digte a nova nota ou pule apentando \"enter\"");
                                string novaNota = Console.ReadLine();
                                if (novaNota != string.Empty)
                                {
                                    Console.WriteLine($"Esta é a nova nota: {novaNota}\nEsta certo? s/n");
                                    string resposta2 = Console.ReadLine();
                                    if (resposta2 == "s" || resposta2 == "S")
                                    {
                                        notaEspecifica.Nota = novaNota;
                                        Console.Clear();
                                        Console.WriteLine("Foi atualizado a nota.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Cancelado com sucesso");
                                    }

                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Digte a nova nota ou pule apentando \"enter\"");
                            string novaNota = Console.ReadLine();
                            if (novaNota != string.Empty)
                            {
                                Console.WriteLine($"Esta é a nova nota: {novaNota}\nEsta certo? s/n");
                                string resposta2 = Console.ReadLine();
                                if (resposta2 == "s" || resposta2 == "S")
                                {
                                    notaEspecifica.Nota = novaNota;
                                    Console.WriteLine("Foi atualizado a nota.");
                                }
                                else
                                {
                                    Console.WriteLine("Cancelado com sucesso");
                                }
                            }
                        }
                    }

                }
                else
                {
                    Console.WriteLine("você não digitou um texto valido");
                }
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        //excluir nota
        static void ExcluirNota()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Digite o titulo da nota que você deseja exluir: ");
                string notaExcluir = Console.ReadLine();
                Console.WriteLine($"Esse titulo esta certo? s/n  \n{notaExcluir}");
                string resposta = Console.ReadLine();
                if (resposta == "s" || resposta == "S")
                {
                    var notaEspecifica = notas.FirstOrDefault(n => n.Titulo == notaExcluir);
                    Console.WriteLine($"Nota achada com sucesso: \n {notaEspecifica.Nota}\n Deseja excluir? s/n");
                    string resposta2 = Console.ReadLine();
                    if (resposta2 == "s" || resposta2 == "S")
                    {
                        notas.Remove(notaEspecifica);
                        Console.WriteLine("Nota excluida com sucesso.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        } 
        // visualizar notas
        static void VisualizarNotas()
        {
            try
            {
                Console.Clear();
                foreach (var nota in notas)
                {
                    Console.WriteLine(nota.Titulo);
                }
                Console.WriteLine("Digite o titulo que você quer ver a nota");
                string tituloNota = Console.ReadLine();
                var notaEspecifica = notas.FirstOrDefault(n => n.Titulo == tituloNota);
                if (notaEspecifica != null)
                {
                    Console.WriteLine(notaEspecifica.Nota);
                }
                else
                {
                    Console.WriteLine("Titulo não encontrado");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        static void MenuPrincipal()
        {
            try
            {
                //Menu principal
                int resposta = 0;
                do
                {
                    Console.WriteLine("Bem vindo, digite a opção que deseja seguir");
                    Console.WriteLine("1 - Adicionar uma nova nota");
                    Console.WriteLine("2 - Alterar uma nota");
                    Console.WriteLine("3 - Exibir as notas");
                    Console.WriteLine("4 - Exluir uma nota");
                    Console.WriteLine("5 - Sair");
                    resposta = Convert.ToInt32(Console.ReadLine());
                    switch (resposta)
                    {
                        case 1:
                            AdicionarNota();
                            break;
                        case 2:
                            AlterarNota();
                            break;
                        case 3:
                            VisualizarNotas();
                            break;
                        case 4:
                            ExcluirNota();
                            break;
                        case 5:
                            resposta = 5;
                            break;
                    }
                } while (resposta != 5);
            }
            catch (FormatException)
            {
                Console.WriteLine("Por favor digite apenas numeros.");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
            
    }


}