using System;
using System.Collections.Generic;
using System.IO;
using ContasBancarias_at.Models;
using ContasBancarias_at.ValidarEntradas;

namespace ContasBancarias_at.Menu
{
    public class Menus
    {
        public static void ExibirMenu(List<Conta> listaDeContas)
        {
            int input = LerComOpcao();
            while (input != 5)
            {
                SelecionarOpcaoMenu(input, listaDeContas);
                input = LerComOpcao();
            }
            FinalizarMenu(listaDeContas);
        }
        
        private static void OpcoesDoMenuPrincipal()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Insira uma das opções abaixo para seguir com o programa:");
            Console.WriteLine("1 - Incluir uma conta");
            Console.WriteLine("2 - Alterar saldo de uma conta");
            Console.WriteLine("3 - Excluir uma conta");
            Console.WriteLine("4 - Gerar um relatório");
            Console.WriteLine("5 - Sair do programa");
            Console.WriteLine("--------------------------------------");
        }
        
        public static int LerComOpcao() {
            bool opcaoValida = false;
            int input = 0;
            do {
                try { 
                    OpcoesDoMenuPrincipal();

                    input = Validacao.LerInteiro();
                    if ((input >= 1) && (input <= 5)) {
                        opcaoValida = true;
                    }
                    else {
                        Console.WriteLine("Entre com uma opção válida");
                    }
                } catch(FormatException) {
                    Console.WriteLine("Formato de entrada inválido");
                }
            } while (!opcaoValida);
            return input;
        }
       
        private static void SelecionarOpcaoMenu(int input, List<Conta> listaDeContas)
        {
            switch (input)
            {
                case 1: 
                    ContaCRUD.Incluirconta(listaDeContas);
                    break;
                case 2:
                    ContaCRUD.AlterarConta(listaDeContas);
                    break;
                case 3:
                    ContaCRUD.ExcluirConta(listaDeContas);
                    break;
                case 4:
                    GerarRelatorio(listaDeContas);
                    break;
                case 5:
                    FinalizarMenu(listaDeContas);
                    break;
            }
        }

        //----------------------------opções do relatório ---------------------------
        public static void GerarRelatorio(List<Conta> listaDeContas)
        {

            int input = LerComOpcaoDoRelatorio();
            while (input != 4)
            {
                SelecionarOpcaoMenuRelatorio(input, listaDeContas);
                input = LerComOpcaoDoRelatorio();
            }

        }

        private static void OpcoesDoMenuRelatorio()
        {
            Console.WriteLine("---------------RELATÓRIOS-----------------");
            Console.WriteLine("Insira uma das opções abaixo para seguir com o programa:");
            Console.WriteLine("1 - Listar clientes com saldo negativo");
            Console.WriteLine("2 - Listar clientes com saldo superior a um valor selecionado");
            Console.WriteLine("3 - Listar todos os clientes");
            Console.WriteLine("4 - Voltar para o menu");
        }

        public static int LerComOpcaoDoRelatorio()
        {
            bool opcaoValida = false;
            int input = 0;
            do
            {
                try
                {
                    OpcoesDoMenuRelatorio();

                    input = Validacao.LerInteiro();
                    if ((input >= 1) && (input <= 4))
                    {
                        opcaoValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Entre com uma opção válida");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Formato de entrada inválido");
                }
            } while (!opcaoValida);
            return input;
        }

        private static void SelecionarOpcaoMenuRelatorio(int input, List<Conta> listaDeContas)
        {
            switch (input)
            {
                case 1:
                    ContaCRUD.MostrarNegativados(listaDeContas);
                    break;
                case 2:
                    ContaCRUD.MostrarValoresSelecionados(listaDeContas);
                    break;
                case 3:
                    ContaCRUD.MostrarTodosClientes(listaDeContas);
                    break;
                case 4:
                    Console.WriteLine("Retornando\n\n");
                    ExibirMenu(listaDeContas);
                    break;
            }
        }

        public static void FinalizarMenu(List<Conta> listaDeContas)
        {
            Console.WriteLine("O programa será finalizado. \nGravando arquivo...");
            try {
                Arquivo.GravarArquivo(listaDeContas);
            } catch (FileNotFoundException) {
                Console.WriteLine("Não foi possivel gravar o arquivo");
            }
        }
    }
}
