using DesignPatternsl.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsl.Decorator
{
    class IC2 : Imposto
    {
        public IC2(Imposto outroImposto) : base(outroImposto) { }
        public IC2() : base() { }
        public override double Calcula(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1 + CalculoDoOutroImposto(orcamento);
        }
    }
}
