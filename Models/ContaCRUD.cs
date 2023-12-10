﻿using ContasBancarias_at.Menu;
using ContasBancarias_at.ValidarEntradas;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ContasBancarias_at.Models
{
    public static class ContaCRUD
    {
        public static void AlterarConta(List<Conta> listaDeContas)
        {
            Conta contaAlterada = PesquisarConta(listaDeContas);
            int input;
            double valor = 0;
            do {
                Console.WriteLine("A alteração é do tipo Débito [1] ou do tipo Crédito [2]");
                input = Validacao.LerInteiro();

                if (input == 1)  {
                    while (valor <= 0) {
                        Console.WriteLine("Insira o valor para debitar");
                        valor = double.Parse(Console.ReadLine().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);
                        if (valor <= 0) {
                            Console.WriteLine("Insira uma quantia válida.");
                        }
                    }
                    Console.WriteLine(contaAlterada.DebitarSaldo(valor));
                    break;
                }

                if (input == 2) {
                    while (valor <= 0) {
                        Console.WriteLine("Insira o valor para creditar");
                        valor = double.Parse(Console.ReadLine().Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);
                        if (valor <= 0) {
                            Console.WriteLine("Insira uma quantia válida.");
                        }
                    }
                    Console.WriteLine(contaAlterada.CreditarSaldo(valor));
                    break;
                }
            }

            while (true);
        }

        public static void Incluirconta(List<Conta> listaDeContas)
        {
            int idNovo;
            string correntistaNovo;
            double saldoNovo;

            try
            {
                if (listaDeContas.Count > 0)
                {
                    Conta ultimaConta = listaDeContas[listaDeContas.Count - 1];
                    idNovo = ultimaConta.Id + 1;
                    Console.WriteLine("Insira o nome e sobrenome do correntista:");
                    correntistaNovo = Console.ReadLine();
                    if (correntistaNovo.Split(' ').Length < 2)
                    {
                        Console.WriteLine("Insira um nome válido com pelo menos dois nomes.");
                        return;
                    }
                    try
                    {
                        Console.WriteLine("Insira o seu saldo inicial: ");
                        saldoNovo = double.Parse(Console.ReadLine().Replace(",", "."), CultureInfo.InvariantCulture);
                        if (saldoNovo < 0)
                        {
                            Console.WriteLine("O valor deve se maior ou igual a zero");
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Insira um valor válido.\n tente novamente.");
                        return;
                    }
                    Conta contaNova = new Conta(idNovo, correntistaNovo, saldoNovo);
                    listaDeContas.Add(contaNova);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("A lista de contas está vazia.");
            }
        }

        public static Conta PesquisarConta(List<Conta> listaDeContas)
        {
            bool opcaoValida = false;
            Conta contaEncontrada = new Conta();

            if (listaDeContas.Count == 0) {
                Console.WriteLine("A lista de contas está vazia.");
                Menus.ExibirMenu(listaDeContas);
            }

            while (!opcaoValida) {
                Console.WriteLine("Insira o ID da conta que você deseja encontrar");
                int inputId = Validacao.LerInteiro();
                contaEncontrada = Validacao.ValidarObjtNaLista(inputId, listaDeContas);
                if (contaEncontrada != null)
                {
                    opcaoValida = true;
                }
            }
            return contaEncontrada;
        }

        public static void ExcluirConta(List<Conta> listaDeContas)
        {
            Conta contaExcluida = PesquisarConta(listaDeContas);

            if (listaDeContas.Contains(contaExcluida))
            {
                bool entradaValida = false;
                do
                {
                    Console.WriteLine($"Você deseja excluir a seguinte conta?\n{contaExcluida}\n\n[1] SIM - [2] NÃO");
                    int input = Validacao.LerInteiro();

                    if (input == 1) {
                        listaDeContas.Remove(contaExcluida);
                        Console.WriteLine($"A conta foi removida com sucesso");
                        entradaValida = true;
                    }
                    
                    if (input == 2) {
                        Console.WriteLine($"A conta NÃO será removida");
                        entradaValida = true;
                    }

                } while (!entradaValida);
            }
            else
            {
                Console.WriteLine("A conta não foi encontrada na lista.");
            }

        }
        /*
         * base da validação da pesquisa de conta
        public static void ExcluirConta(List<Conta> listadeContas)
        {
            do { 
            Console.WriteLine("Insira um número da conta que você deseja excluir");
            int input = int.Parse(Console.ReadLine());
            if (input  <= 0)
                {
                    Console.WriteLine("Insira um número válido, maior que zero");
                }
            if (input > listadeContas.Count)
                {
                    Console.WriteLine("Insira um número válido e disponível");
                }
            
            } while (true);
        }
        */
        public static void MostrarNegativados(List<Conta> listaDeContas)
        {
            List<Conta> contasNegativas = new List<Conta>();
            try
            {
                foreach (Conta cc in listaDeContas)
                {
                    if (cc.TemSaldoNegativo())
                    {
                        contasNegativas.Add(cc);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Não existe clientes negativados");
            }

            foreach (Conta cc in contasNegativas)
            {
                Console.WriteLine(cc);
            }
        }

        public static void MostrarValoresSelecionados(List<Conta> listaDeContas)
        {
            double saldoAPesquisar;
            Console.WriteLine("Qual o valor que deseja pesquisar?");
            try
            {
                saldoAPesquisar = double.Parse(Console.ReadLine());
                if (saldoAPesquisar > 0)
                {
                    foreach (Conta cc in listaDeContas)
                    {
                        if (cc.TemSaldoCompativel(saldoAPesquisar))
                        {
                            Console.WriteLine(cc);
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Insira um valor maior que zero.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Insira um valor válido.");

            }
        }

        public static void MostrarTodosClientes(List<Conta> listaDeContas)
        {
            foreach (Conta cc in listaDeContas)
            {
                Console.WriteLine(cc);
            }
        }

        
    }

}