using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContasBancaias_at.Models
{
    public interface InterfaceConta
    {
        void DebitarSaldo(double valor);

        void CreditarSaldo(double valor);

    }
}
