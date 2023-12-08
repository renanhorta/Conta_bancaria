
namespace ContasBancaias_at.Models
{
    public class Conta
    {
        protected int id { get; set; }
        protected string correntista { get; set; }
        protected double saldo { get; set; }

        public Conta() { }
        public Conta(int id, string correntista, double saldo)
        {
            this.id = id;
            this.correntista = correntista;
            this.saldo = saldo;
        }
        public int GetIdConta()
        {
            return id;
        }
        public override string ToString()
        {
            return "\n\nNum de conta " + id + "\nCorretista: " +correntista + "\nSaldo: " + " R$ " + saldo;
        }

        public string salvarContaCSV()
        {
            return this.id + ";" + this.correntista + ";" + this.saldo;
        }

        public bool temSaldoNegativo()
        {
            return saldo < 0;
        }
        
        public bool temSaldoCompativel(double saldoTeto)
        {
            if (saldo >= saldoTeto) {
                return true;
            }
            else {
                return false;
            }
        }
    }
}
