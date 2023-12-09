using ContasBancarias_at.Models;
using System.Collections.Generic;
using ContasBancarias_at.Menu;


namespace ContasBancarias_at
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Conta> listaContas = new List<Conta>();
            Arquivo.LerArquivo(listaContas);
            MenuExibido.ExibirMenu(listaContas);
            
        }

    }
}
