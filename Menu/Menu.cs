using System;
using System.Collections.Generic;
using ContasBancarias_at.Models;
using ContasBancarias_at.ValidarEntradas;

namespace ContasBancarias_at.Menu
{
    public class Menus
    {
        public static void ExibirMenu(List<Conta> listaDeContas)
        {
            const int FIM = 5;
            int input = LerComOpcao();
            while (input != FIM)
            {
                SelecionarOpcaoMenu(input, listaDeContas);
                input = LerComOpcao();
            }
        }
        public static void OpcoesDoMenuPrincipal()
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
            int input = 0; ;
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
        public static void SelecionarOpcaoMenu(int input, List<Conta> listaDeContas)
        {
            switch (input)
            {
                case 1: ContaCRUD.Incluirconta(listaDeContas);
                    break;
                case 2:
                    ContaCRUD.AlterarConta(listaDeContas);
                    break;
                case 3:
                    ContaCRUD.ExcluirConta(listaDeContas); ;
                    break;
                case 4:
                    GerarRelatorio(listaDeContas); ;
                    break;
                case 5:
                    Console.WriteLine("O programa ira ser fechado. \n Gravando arquivo...");
                    Arquivo.GravarArquivo(listaDeContas);
                    break;
            }
        }
        public static void GerarRelatorio(List<Conta> listaDeContas)
        {

        }
        /*
        public void gerarRelatorio(List<Conta> conta) {
            int input;
            do {
                Console.WriteLine("---------------RELATÓRIOS-----------------");
                Console.WriteLine("Insira uma das opções abaixo para seguir com o programa:");
                Console.WriteLine("1 - Listar clientes com saldo negativo");
                Console.WriteLine("2 - Listar clientes com saldo superior a um valor selecionado");
                Console.WriteLine("3 - Listar todos os clientes");
                Console.WriteLine("4 - Voltar para o menu");
                input = int.Parse(Console.ReadLine());
                validarRelatorio(input, conta);
            } while (input < 1 || input > 4);
        }

        public void validarRelatorio(int input, List<Conta> conta) {
            if (conta.Count > 0){
                switch (input)
                {
                    case 1:
                        mostrarNegativados(conta);
                        break;
                    case 2:
                        mostrarValoresSelecionados(conta);
                        break;
                    case 3:
                        mostrarTodosClientes(conta);
                        break;
                    case 4:
                        Console.WriteLine("Retornando\n\n");
                        exibirMenu(conta);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida.");
                        exibirMenu(conta);
                        break;
                }
            }
            else {
                Console.WriteLine("A lista está vazia.");
                exibirMenu(conta);
            }
        }
        
        public void finalizarMenu(List<Conta> conta)
        {
            Console.WriteLine("O programa será finalizado. \nGravando arquivo...");
            try {
                using (var arquivo = new StreamWriter(localArquivo)) {
                    foreach(Conta cc in conta) {
                        arquivo.WriteLine(cc.salvarContaCSV());
                    }
                }
            } catch (FileNotFoundException) {
                Console.WriteLine("Não foi possivel gravar o arquivo");
                exibirMenu(conta);
            }
        }
        */
    }
}
