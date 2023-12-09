using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Policy;

namespace ContasBancarias_at.Models
{
    public class Arquivo
    {
        const string caminhoArquivo = @"C:\Users\Renan_PC\source\repos\ContasBancaias_at\utils\csv_conta.csv";
        public static List<Conta> LerArquivo(List<Conta> listadeContas)
        {
            try
            {
                using (var arquivo = new StreamReader(caminhoArquivo))
                {
                    bool cabecalhoLido = false;
                    string linha = arquivo.ReadLine();
                    while (linha != null)
                    {
                        if (!cabecalhoLido)
                        {
                            string[] campos = linha.Split(';');
                            int id = int.Parse(campos[0]);
                            string nome = campos[1];
                            double saldo = double.Parse(campos[2].Replace(".", "").Replace(",", "."), CultureInfo.InvariantCulture);
                            listadeContas.Add(new Conta(id, nome, saldo));
                        }
                        else
                        {
                            cabecalhoLido = true;
                        }
                        linha = arquivo.ReadLine();
                    }
                }
            }catch (Exception)
            {
                Console.WriteLine("Erro na leitura do arquivo CSV.");
            }

            return listadeContas;
        }

        public static void GravarArquivo(List <Conta> listadeContas)
        {
            try
            {
                using (var arquivo = new StreamWriter(caminhoArquivo))
                {
                    foreach(Conta conta in listadeContas)
                    {
                        arquivo.WriteLine(conta.SalvarContaCSV());
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Erro na gravação de arquivo.");
            }
        }
    }
}
