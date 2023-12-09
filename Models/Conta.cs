
using ContasBancaias_at.Models;
using System;

namespace ContasBancarias_at
{
    public class Conta : InterfaceConta
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
        public string DebitarSaldo(double valor)
        {
            Saldo -= valor;

            if (Saldo < 0)
            {
                return $"Com um débito no valor de {valor} reais. O(a) Correntista(a) {Correntista} está negativado(a).\nSaldo: R$ {Saldo}";
            }

            if (Saldo == 0)
            {
                return $"Com um débito no valor de {valor} reais. O(a) Correntista(a) {Correntista} está com a conta zerada.";
            }

            return $"Foi feito um débito no valor de {valor} reais.\nSaldo: R$ {Saldo}";
        }


        public string CreditarSaldo(double valor)
        {
            Saldo += valor;
            return $"Foi creditado um valor de {valor} na sua Conta, {Correntista}";
        }
    }
}
