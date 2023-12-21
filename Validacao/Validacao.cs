using ContasBancarias_at.Menu;
using ContasBancarias_at.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;

namespace ContasBancarias_at.ValidarEntradas
{
    public class Validacao { 
        
        public static int LerInteiro()
        {
            int num = 0;
            do
            {
                try
                {
                    Console.WriteLine("Entre com a opção: ");
                    num = int.Parse(Console.ReadLine());
                    break;
                }catch (FormatException)
                {
                    Console.WriteLine("Tipo de entrada inválida");
                }
            }while (true);
            return num;

        }
        public static Conta ValidarObjtNaLista(int IdPesquisado, List<Conta> listaDeContas)
        {
            foreach(Conta conta in listaDeContas)
            {
                if(conta.Id == IdPesquisado)
                {
                    return conta;
                }
            }
            return null;
        }
     
        public static bool verificarSaldoNulo(Conta conta)
        {
            bool saldoNulo = false;
            if (conta.Saldo != 0) {
                Console.WriteLine("A conta não pode ser excluida por ter saldo ativo");
                Menus.LerComOpcao();
            }
            else {
                saldoNulo = true;
            }
            return saldoNulo;
        }
        
        public static string ValidarNomeComposto()
        {
            string correntistaNovo;

            do {
                Console.WriteLine("Insira o nome e sobrenome do correntista:");
                correntistaNovo = Console.ReadLine();

                if (string.IsNullOrEmpty(correntistaNovo)) {
                    Console.WriteLine("Insira um nome.");
                }// verifica se tem pelo menos 2 nomes
                else if (correntistaNovo.Split(' ').Length < 2) {
                    Console.WriteLine("Insira um nome válido com pelo menos dois nomes.");
                }// verifica se ao dividir o nome tem algum sim ou num
                else if (correntistaNovo.Split(' ').Any(palavra => !palavra.All(char.IsLetter))) {
                    Console.WriteLine("Insira um nome válido, sem repetições de letras.");
                }// verifica se os nomes tem somente letras
                else if (correntistaNovo.Any(caracter => !char.IsLetter(caracter) && caracter != ' ')) {
                    Console.WriteLine("Insira um nome válido, sem números ou símbolos.");
                }// verifica se os nomes são identicos
                else if (!CorrentistaUnico(correntistaNovo)) {
                    Console.WriteLine("Insira um nome válido, sem repetições de nomes.");
                }
                else {
                    break;
                }
            } while (true);

            return correntistaNovo;
        }
        
        private static bool CorrentistaUnico(string nome)
        {
            string[] nomes = nome.Split(' ');

            for (int i = 0; i < nomes.Length - 1; i++) {
                for (int j = i + 1; j < nomes.Length; j++) {
                    if (nomes[i].Equals(nomes[j], StringComparison.OrdinalIgnoreCase)) {
                        return false;
                    }
                }
            }

            return true;
        }
       
        public static double ValidarSaldo()
        {
            double saldoNovo;
            
            do {
                Console.WriteLine("Insira o saldo:");
                string input = Console.ReadLine();

                if (double.TryParse(input.Replace(",", "."), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out saldoNovo)) {
                    if (saldoNovo > 0) {
                        return saldoNovo;
                    }
                    else {
                        Console.WriteLine("Insira um valor maior que zero.");
                    }
                }
                else {
                    Console.WriteLine("Insira um valor válido.");
                }

            } while (true);
        }

        public static double ValidarSaldoNovo()
        {
            double saldoNovo;

            do {
                Console.WriteLine("Insira o saldo:");
                string input = Console.ReadLine();

                if (double.TryParse(input.Replace(",", "."), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out saldoNovo)) {
                    if (saldoNovo >= 0) {
                        return saldoNovo;
                    }
                }
                else {
                    Console.WriteLine("Insira um valor válido. Maior ou igual a zero");
                }

            } while (true);
        }

        public static void ValidarValorDeAlteracao(Conta contaAlterada)
        {
            int input;
            double valor = 0;
            do
            {
                Console.WriteLine("Insira a opção [1] para DEBITAR e [2] para CREDITAR.");
                input = Validacao.LerInteiro();
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Insira o valor para debitar");
                        valor = double.Parse(Console.ReadLine().Replace(",", "."), CultureInfo.InvariantCulture);
                        Console.WriteLine(contaAlterada.DebitarSaldo(valor));
                        break;
                    case 2:
                        Console.WriteLine("Insira o valor para creditar");
                        valor = double.Parse(Console.ReadLine().Replace(",", "."), CultureInfo.InvariantCulture);
                        Console.WriteLine(contaAlterada.CreditarSaldo(valor));
                        break;
                    default:
                        Console.WriteLine("Insira uma opção válida (1 ou 2)");
                        break;
                }
            } while(input != 1 && input != 2);
        }

        public static int PedirIdAoUsuario()
        {
            int id;
            Console.Write("Digite o ID da nova conta: ");
            while (!int.TryParse(Console.ReadLine(), out id) || id <= 0)
            {
                Console.WriteLine("ID inválido. Por favor, digite um número inteiro positivo.");
                Console.Write("Digite o ID da nova conta: ");
            }
            return id;
        }

        public static bool ContaExisteNaLista(List<Conta> listaDeContas, int id)
        {
            return listaDeContas.Any(conta => conta.Id == id);
        }
    }
}
