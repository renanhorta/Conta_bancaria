using ContasBancaias_at.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace ContasBancaias_at
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Conta> conta = new List<Conta>();

            conta = lerConta(conta);
            exibirConta(conta);
        }

        public static List<Conta> lerConta(List<Conta> conta)
        {   
            const string localArquivo = @"C:\Users\Renan_PC\source\repos\ContasBancaias_at\utils\csv_conta.csv";
            try
            {
                using (var arquivo = new StreamReader(localArquivo))
                {
                    bool primeiraLinha = true;
                    string linha = arquivo.ReadLine();
                    while (linha != null)
                    {   
                        if (!primeiraLinha)
                        {
                            try
                            {
                                // adicionar um try catch para as entradas numericas
                                string[] campos = linha.Split(';');
                                int numConta = int.Parse(campos[0]);
                                string correntista = campos[1];
                                double saldo = double.Parse(campos[2]);
                                conta.Add(new Conta(numConta, correntista, saldo));
                            } catch
                                {
                                Console.WriteLine("Erro nos dados dos arquivos.");
                                }
                        }
                        else
                        {
                            //pula primeira linha
                            primeiraLinha = false;
                        }

                        linha = arquivo.ReadLine();
                    }
                }

            } catch (Exception ex){
                Console.WriteLine("Erro na leitura do arquivo.");
            }

            return conta;
        }
        
        public static void exibirConta(List<Conta> lista) { 
            foreach (Conta conta in lista)
            {
                Console.WriteLine(conta);
            }
        }
    }
}
