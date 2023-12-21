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
            Console.WriteLine(contaAlterada.ToString());
            do {
                try {
                    Validacao.ValidarValorDeAlteracao(contaAlterada);
                    break;
                }catch(Exception) {
                    Console.WriteLine("Insira uma opção válida");
                }
            }
            while (true);

        }

        public static void Incluirconta(List<Conta> listaDeContas)
        {
            int idNovo;
            string correntistaNovo;
            double saldoNovo;

            do {
                idNovo = Validacao.PedirIdAoUsuario();

                if (Validacao.ContaExisteNaLista(listaDeContas, idNovo)) {
                    Console.WriteLine("Já existe uma conta com o ID fornecido. Por favor, escolha outro ID.");
                }
            } while (Validacao.ContaExisteNaLista(listaDeContas, idNovo));

            correntistaNovo = Validacao.ValidarNomeComposto();
            saldoNovo = Validacao.ValidarSaldoNovo();

            try {
                Conta contaNova = new Conta(idNovo, correntistaNovo, saldoNovo);
                listaDeContas.Add(contaNova);
                Console.WriteLine("Conta adicionada com sucesso!");
            }
            catch (Exception ex) {
                Console.WriteLine("Não foi possível adicionar a nova conta. Erro: " + ex.Message);
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
                if (contaEncontrada != null) {
                    opcaoValida = true;
                }
            }
            return contaEncontrada;
        }
       
        public static void ExcluirConta(List<Conta> listaDeContas)
        {
            Conta contaExcluida = PesquisarConta(listaDeContas);

            if (listaDeContas.Contains(contaExcluida)) {
                bool entradaValida = false;
                do {
                    Console.WriteLine($"Você deseja excluir a seguinte conta?\n{contaExcluida}\n\n[1] SIM - [2] NÃO");
                    int input = Validacao.LerInteiro();

                    if (input == 1) {
                        if(Validacao.verificarSaldoNulo(contaExcluida) == true) {
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
            else {
                Console.WriteLine("A conta não foi encontrada na lista.");
            }

        }
        
        public static void MostrarNegativados(List<Conta> listaDeContas)
        {
            List<Conta> contasNegativas = new List<Conta>();
            try {
                foreach (Conta cc in listaDeContas) {
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
