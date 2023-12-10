using ContasBancarias_at.Models;
using System;
using System.Collections.Generic;

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

        public static Conta ValidarObjtNaLista (int num, List<Conta> listaDeContas)
        {
            if ((num > 0) && (num < listaDeContas.Count))
            {
                Conta contaEncontrada = listaDeContas.Find(conta => conta.Id == num);
                return contaEncontrada;
            }
            else
            {
                Console.WriteLine("Conta não encontrada.");
                return null;
            }
        }
    }
}
