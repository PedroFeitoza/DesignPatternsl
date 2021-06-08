using DesignPatternsl.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsl.Decorator
{
    class IC1 : Imposto
    {
        public IC1(Imposto outroImposto) : base(outroImposto) { }
        public IC1() : base() { }

        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.05 + CalculoDoOutroImposto(orcamento);
        }

        private double CalculoDoOutroImposto(Orcamento orcamento)
        {
            return OutroImposto.Calcula(orcamento);
        }
    }
}
