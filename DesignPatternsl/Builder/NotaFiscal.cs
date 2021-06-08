using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsl.Builder
{
    public class NotaFiscal
    {
        private String RazaoSocial { get; set; }
        private String Cnpj { get; set; }
        private DateTime DataDeEmissao { get; set; }
        private double ValorBruto { get; set; }
        private double Impostos { get; set; }
        private IList<ItemDaNota> Itens { get; set; }
        private String Observacoes { get; set; }

        public NotaFiscal(String razaoSocial, String cnpj, DateTime dataDeEmissao,
                      double valorBruto, double impostos, IList<ItemDaNota> itens,
                      String observacoes)
        {
            Cnpj = cnpj;
            RazaoSocial = razaoSocial;
            DataDeEmissao = dataDeEmissao;
            ValorBruto = valorBruto;
            Impostos = impostos;
            Itens = itens;
            Observacoes = observacoes;
        }

        public override string ToString()
        {
            return @$"{ Cnpj }  
                      { RazaoSocial }
                      { DataDeEmissao }
                      { ValorBruto }
                      { Impostos }
                      { Itens.Count }
                      {Observacoes}";
        }
    }
}
