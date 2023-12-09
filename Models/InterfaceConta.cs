namespace ContasBancaias_at.Models
{
    public interface InterfaceConta
    {
        string DebitarSaldo(double valor);

        string CreditarSaldo(double valor);

    }
}
