
namespace ContasBancaias_at.Models
{
    public class Conta
    {
        protected int numConta { get; set; }
        protected string correntista { get; set; }
        protected double saldo { get; set; }

        public Conta() { }
        public Conta(int numConta, string correntista, double saldo)
        {
            this.numConta = numConta;
            this.correntista = correntista;
            this.saldo = saldo;
        }
        public int GetNumConta()
        {
            return numConta;
        }
        public override string ToString()
        {
            return correntista + "-" +numConta + " R$" + saldo;
        }

        public string salvarConta()
        {
            return this.numConta + ";" + this.correntista + ";" + this.saldo;
        }
    }
}
