using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancaias_at.Models
{
    public class Menu
    {
        //public List<Conta> listaContas = new List<Conta>();
        public string localArquivo;
        public Menu(string localArquivo) {
            this.localArquivo = localArquivo;//.Replace("/", "//");
        }

        public void exibirMenu(List<Conta> conta)
        {   
            List<Conta> listaContas = conta;
            int input;

            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Insira uma das opções abaixo para seguir com o programa:");
                Console.WriteLine("1 - Incluir uma conta");
                Console.WriteLine("2 - Excluir uma conta");
                Console.WriteLine("3 - Gerar um relatório");
                Console.WriteLine("4 - Sair do menu");
                Console.WriteLine("--------------------------------------");
                input = int.Parse(Console.ReadLine());
                validarEntrada(input, conta);
            } while (input < 1 || input > 4);
        }

        public void validarEntrada(int input, List<Conta> conta)
        {
            List<Conta> listaContas = conta;
            switch (input)
            {
                case 1:
                    Console.WriteLine("Incluir");
                    incluirconta(conta);
                    break;
                case 2:
                    Console.WriteLine("excluir");
                    //excluirConta(conta);
                    break;
                case 3:
                    Console.WriteLine("relatorio");
                    //gerarRelatorio(conta);
                    break;
                case 4:
                    Console.WriteLine("sair");
                    finalizarMenu(conta);
                    break;
                default:
                    Console.WriteLine("Opção Inválida.");
                    break;
            }
        }

        public void incluirconta(List<Conta> conta)
        {

            if (conta.Count > 0)
            {
                Conta ultimaConta = conta[conta.Count - 1];
                int numContaNovo = (ultimaConta.GetNumConta() + 1);
                Console.WriteLine(numContaNovo);
                //try{
                //    Conta contaNova = new Conta(numContaNovo,)        
                //}
            }
            else
            {
                Console.WriteLine("A lista de contas está vazia.");
            }

        }
        
        public void finalizarMenu(List<Conta> listaConta)
        {
            Console.WriteLine("O programa será finalizado. \nGravando arquivo...");
            try
            {
                using (var arquivo = new StreamWriter(localArquivo))
                {
                    foreach(Conta conta in listaConta)
                    {
                        arquivo.WriteLine(conta.salvarConta());
                    }
                }
            } catch (FileNotFoundException) 
            {
                Console.WriteLine("Não foi possivel gravar o arquivo");
            }
        }
    }
}

