using DesignPatternsl.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsl
{
    class CalculadorDeImposto
    {
        public void RealizaCalculo(Orcamento orcamento, IImposto estrategiaDeImposto)
        {
            double taxa = estrategiaDeImposto.Calcula(orcamento);
            Console.WriteLine(taxa);
        }
    }
}
