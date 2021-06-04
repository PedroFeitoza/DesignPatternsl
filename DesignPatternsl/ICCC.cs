using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsl
{
    public class ICCC : Imposto
    {
        public double Calcula(Orcamento orcamento)
        {
            switch (orcamento.Valor)
            {
                case <1000:
                    return orcamento.Valor * 0.05;
                case <=3000:
                    return orcamento.Valor * 0.07;
                case >3000:
                    return orcamento.Valor * 0.08 + 30;
                default:
                    return 0;
            }
        }
    }
}
