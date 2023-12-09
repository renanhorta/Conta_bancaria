using System;
using System.Collections.Generic;
using System.Globalization;

namespace ContasBancarias_at.Models
{
    public static class ContaCRUD
    {
        public static void AlterarConta(Conta conta)
        {
            do
            {
                Console.WriteLine("A alteração é do tipo Débito [1] ou do tipo Crédito [2]");
                int input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("Insira o valor para debitar");
                    double valor = double.Parse(Console.ReadLine());
                    Console.WriteLine(conta.DebitarSaldo(valor));
                    break;
                }
                if (input == 2)
                {
                    Console.WriteLine("Insira o valor para creditar");
                    double valor = double.Parse(Console.ReadLine());
                    Console.WriteLine(conta.CreditarSaldo(valor));
                    break;
                }
                Console.WriteLine("Etre com um valor válido.");
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
            Console.WriteLine("Insira o ID da conta que você deseja encontrar:");
            int inputId = int.Parse(Console.ReadLine());

            try
            {
                Conta contaEncontrada = listaDeContas.Find(conta => conta.Id == inputId);
                if (contaEncontrada != null)
                {
                    return contaEncontrada;
                }
                else
                {
                    Console.WriteLine("Conta não encontrada.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
                return null;
            }
        }

        public static void ExcluirConta(List<Conta> listaDeContas)
        {
            Conta contaExcluida = PesquisarConta(listaDeContas);
            if (listaDeContas.Contains(contaExcluida))
            {
                bool entradaValida = false;
                do
                {
                    Console.WriteLine($"Você deseja excluir a seguinte conta?\n{contaExcluida}\n[1] SIM - [2] NÃO");
                    if (int.TryParse(Console.ReadLine(), out int input)) {
                        if (input == 1)
                        {
                            listaDeContas.Remove(contaExcluida);
                            Console.WriteLine($"A conta foi removida com sucesso");
                            entradaValida = true;
                        }
                        else if (input == 2)
                        {
                            Console.WriteLine($"A conta NÃO será removida");
                            entradaValida = true;
                        }
                        else
                        {
                            Console.WriteLine("Insira 1 para SIM ou 2 para NÃO.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Insira um número válido (1 ou 2).");
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

        public static void MostrarTodosClientes(List<Conta> conta)
        {
            foreach (Conta cc in conta)
            {
                Console.WriteLine(cc);
            }
        }

        
    }

}
