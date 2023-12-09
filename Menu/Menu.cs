/*using ContasBancarias_at.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace ContasBancarias_at.Menu
{
    public class Menu
    {
        public static int input;

        public static void exibirMenu(List<Conta> conta)
        {             
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Insira uma das opções abaixo para seguir com o programa:");
                Console.WriteLine("1 - Incluir uma conta");
                Console.WriteLine("2 - Alterar uma conta");
                Console.WriteLine("3 - Excluir uma conta");
                Console.WriteLine("4 - Gerar um relatório");
                Console.WriteLine("5 - Sair do menu");
                Console.WriteLine("--------------------------------------");
                input = int.Parse(Console.ReadLine());
                Validacao.validarEntrada(input, conta);
            } while (input != 5);
        }

 
        
        public void incluirconta(List<Conta> conta) {
            int idNovo;
            string correntistaNovo;
            double saldoNovo;

            try {
                if (conta.Count > 0) {
                    Conta ultimaConta = conta[conta.Count - 1];
                    idNovo = ultimaConta.Id + 1;
                    Console.WriteLine("Insira o nome e sobrenome do correntista:");
                    correntistaNovo = Console.ReadLine();
                    if (correntistaNovo.Split(' ').Length < 2) {
                        Console.WriteLine("Insira um nome válido com pelo menos dois nomes.");
                        incluirconta(conta);
                        return;
                    }

                    try {
                    Console.WriteLine("Insira o seu saldo inicial: ");
                    saldoNovo = double.Parse(Console.ReadLine().Replace(",", "."), CultureInfo.InvariantCulture);
                    if (saldoNovo < 0) {
                        Console.WriteLine("O valor deve se maior ou igual a zero");
                        incluirconta(conta);
                        return;
                    }
                        
                    } catch (Exception) {
                        Console.WriteLine("Insira um valor válido.\n tente novamente.");
                        incluirconta(conta);
                        return;
                    }

                    Conta contaNova = new Conta(idNovo, correntistaNovo, saldoNovo);
                    conta.Add(contaNova);
                    exibirMenu(conta);
                        
                }
            }
            catch (Exception)
            {
                Console.WriteLine("A lista de contas está vazia.");
                exibirMenu(conta);
            }

        }
        
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
        
        public void mostrarNegativados(List<Conta> conta) {
            List<Conta> contasNegativas = new List<Conta>();
            try {
                foreach (Conta cc in conta) {
                    if (cc.temSaldoNegativo()) {
                        contasNegativas.Add(cc);

                    }
                }
            }
            catch (Exception) {
                Console.WriteLine("Não existe clientes negativados");
                exibirMenu(conta);
            }

            foreach (Conta cc in contasNegativas) {
                Console.WriteLine(cc);
            }
            exibirMenu(conta);
        }
        
        public void mostrarValoresSelecionados(List<Conta> conta) {
            double saldoAPesquisar;
            Console.WriteLine("Qual o valor que deseja pesquisar?");

            try {
                saldoAPesquisar = double.Parse(Console.ReadLine());
                if (saldoAPesquisar > 0) {
                    foreach (Conta cc in conta) {
                        if (cc.temSaldoCompativel(saldoAPesquisar)) {
                            Console.WriteLine(cc);
                        }
                    }
                    exibirMenu(conta);
                }
                else{
                    Console.WriteLine("Insira um valor maior que zero.");
                    mostrarValoresSelecionados(conta);
                }    
            }catch(Exception) {
                Console.WriteLine("Insira um valor válido.");
                gerarRelatorio(conta);
            }
        }
        
        public void mostrarTodosClientes(List<Conta> conta)
        {
            foreach (Conta cc in conta)
            {
                Console.WriteLine(cc);
            }
            exibirMenu(conta);
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
    }
}

*/