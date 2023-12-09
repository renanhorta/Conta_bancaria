
namespace ContasBancarias_at
{
    public class Conta
    {
        public int Id { get; set; }
        public string Correntista { get; set; }
        public double Saldo { get; set; }

        public Conta() { }
        public Conta(int id, string correntista, double saldo)
        {
            Id = id;
            Correntista = correntista;
            Saldo = saldo;
        }
        public override string ToString()
        {
            return "\n\nNum de conta " + Id + "\nCorretista: " +Correntista + "\nSaldo: " + " R$ " + Saldo;
        }

        public string SalvarContaCSV()
        {
            return Id + ";" + Correntista + ";" + Saldo;
        }

        public bool TemSaldoNegativo()
        {
            return Saldo < 0;
        }

        public bool TemSaldoCompativel(double saldoTeto)
        {
            return Saldo >= saldoTeto;
        }
    }
}
