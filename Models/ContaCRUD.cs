using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public static void ExcluirConta1(List<Conta> listaDeContas)
        {
            Conta contaexcluida = PesquisarConta(listaDeContas);
            if (listaDeContas.Contains(contaexcluida))
            {
                listaDeContas.Remove(contaexcluida);
                Console.WriteLine($"A seguinte conta foi removida com sucesso.{contaexcluida} ");
            }
            else
            {
                Console.WriteLine($"A conta não foi encontrado na lista.");
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
    }

}
