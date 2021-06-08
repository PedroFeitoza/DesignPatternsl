using DesignPatternsl.Builder;
using DesignPatternsl.ChainOfResponsability;
using DesignPatternsl.Decorator;
using DesignPatternsl.Strategy;
using DesignPatternsl.TemplateMethod;
using DesignPatternsl.Observer;
using System;

namespace DesignPatternsl
{
    class Program
    {
        static void Main(string[] args)
        {
            //Strategy
            IImposto iss = new Iss();
            IImposto icms = new Icms();
            IImposto iccc = new ICCC();

            var orcamento = new Orcamento(3100);

            var calculador = new CalculadorDeImposto();
            calculador.RealizaCalculo(orcamento, iss);
            calculador.RealizaCalculo(orcamento, icms);
            calculador.RealizaCalculo(orcamento, iccc);
            Console.WriteLine("Hello World!");

            //ChainOfResponsability
            var calculadordeDesconto = new CalculadorDeDesconto();
            var orcamentoComDesconto = new Orcamento(500);

            orcamentoComDesconto.AdicionaItem(new Item("CANETA", 500));
            orcamentoComDesconto.AdicionaItem(new Item("LAPIS", 500));

            double desconto = calculadordeDesconto.Calcula(orcamentoComDesconto);
            Console.WriteLine($"Desconto do Orçamento: {desconto}");

            //Decorator
            Imposto icpp = new IC1(new IC2());

            var orcamentoComImpostoComposto = new Orcamento(1000);
            double valor = icpp.Calcula(orcamentoComImpostoComposto);
            Console.WriteLine($"Imposto Composto: {valor}");

            //State
            Orcamento reforma = new Orcamento(500);
            Console.WriteLine($"Orçamento com estado inicial:{reforma.Valor}");
            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);
            
            reforma.Aprova();

            reforma.AplicaDescontoExtra();
            Console.WriteLine(reforma.Valor);
            reforma.Finaliza();


            //Builder
            NotaFiscal nf = new NotaFiscalBuilder()
                            .ParaEmpresa("Caelum")
                            .ComCnpj("123.456.789/0001-10")
                            .ComItem(new ItemDaNota("item 1", 100.0))
                            .ComItem(new ItemDaNota("item 2", 200.0))
                            .ComItem(new ItemDaNota("item 3", 300.0))
                            .ComObservacoes("entregar nf pessoalmente")
                            .NaDataAtual()
                            .Constroi(); //Fluent Interface
            
            Console.WriteLine(nf);

            //Observer
            var criadorNf2 = new NotaFiscalBuilder2()
                            .ParaEmpresa("Caelum2")
                            .ComCnpj("123.456.789/0002-20")
                            .ComItem(new ItemDaNota("item 1", 100.0))
                            .ComItem(new ItemDaNota("item 2", 200.0))
                            .ComItem(new ItemDaNota("item 3", 300.0))
                            .ComObservacoes("entregar nf virtualmente")
                            .NaDataAtual();

                            NotaFiscal nf2 = criadorNf2.Constroi();
                            Console.WriteLine(nf2);

                            criadorNf2.AdicionaAcao(new EnviadorDeSms());
                            criadorNf2.AdicionaAcao(new Impressora());
                            criadorNf2.AdicionaAcao(new NotaFiscalDao());
                            criadorNf2.VizualizaAcoes(nf2);           
        }
    }
}
