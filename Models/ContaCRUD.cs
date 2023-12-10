using ContasBancarias_at.Menu;
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
                        valor = double.Parse(Console.ReadLine().Replace(",", "."), CultureInfo.InvariantCulture);
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
                        valor = double.Parse(Console.ReadLine().Replace(",", "."), CultureInfo.InvariantCulture);
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

            //Conta ultimaConta = listaDeContas[listaDeContas.Count - 1];
            if (listaDeContas.Count == 0) {
                idNovo = 1;
            }
            else {
                Conta ultimaConta = listaDeContas[listaDeContas.Count - 1];
                idNovo = ultimaConta.Id + 1;
            }

            correntistaNovo = Validacao.ValidarNomeComposto();
            saldoNovo = Validacao.ValidarSaldoNovo();

            try {
                Conta contaNova = new Conta(idNovo, correntistaNovo, saldoNovo);
                listaDeContas.Add(contaNova);
            } catch (Exception ex) { 
                Console.WriteLine("Não foi possivel adicionar a nova conta.\n Error: " + ex); 
            }
            
        }
       
        public static Conta PesquisarConta(List<Conta> listaDeContas)
        {
            bool opcaoValida = false;
            Conta contaEncontrada = new Conta();

            if (listaDeContas.Count == 0) {
                Console.WriteLine("A lista de contas está vazia.");
                Menus.LerComOpcao();
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
                        if(Validacao.verificarSaldoNulo(contaExcluida) == true)
                        {
                            listaDeContas.Remove(contaExcluida);
                            Console.WriteLine($"A conta foi removida com sucesso");
                            entradaValida = true;
                        }
                        
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
