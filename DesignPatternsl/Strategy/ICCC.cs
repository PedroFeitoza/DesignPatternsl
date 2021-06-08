using DesignPatternsl.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsl
{
    public class ICCC : IImposto
    {
        public double Calcula(Orcamento orcamento)
        {
            var valor = orcamento.Valor;
            switch (valor)
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
