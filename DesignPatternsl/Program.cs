using System;

namespace DesignPatternsl
{
    class Program
    {
        static void Main(string[] args)
        {
            Imposto iss = new Iss();
            Imposto icms = new Icms();
            Imposto iccc = new ICCC();

            Orcamento orcamento = new Orcamento(3100);

            CalculadorDeImposto calculador = new CalculadorDeImposto();
            calculador.RealizaCalculo(orcamento, iss);
            calculador.RealizaCalculo(orcamento, icms);
            calculador.RealizaCalculo(orcamento, iccc);
            Console.WriteLine("Hello World!");
        }
    }
}
