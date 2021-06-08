using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsl.Builder
{
    public class NotaFiscalBuilder
    {
        public String RazaoSocial { get; set; }
        private String Cnpj { get; set; }
        private double ValorTotal { get; set; }
        private double Impostos { get; set; }
        private DateTime Data { get; set; }
        private String Observacoes { get; set; }

        private IList<ItemDaNota> TodosItens = new List<ItemDaNota>();

        public NotaFiscal Constroi()
        { return new NotaFiscal(RazaoSocial, Cnpj, Data, ValorTotal, Impostos, TodosItens, Observacoes); }
        public NotaFiscalBuilder ParaEmpresa(String razaoSocial)
        {
            RazaoSocial = razaoSocial;
            return this;
        }

        public NotaFiscalBuilder ComCnpj(String cnpj)
        {
            Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder ComItem(ItemDaNota item)
        {
            TodosItens.Add(item);
            ValorTotal += item.Valor;
            Impostos += item.Valor * 0.05;
            return this;
        }

        public NotaFiscalBuilder ComObservacoes(String observacoes)
        {
            Observacoes = observacoes;
            return this;
        }

        public NotaFiscalBuilder NaDataAtual()
        {
            Data = DateTime.Now;
            return this;
        }

    }
}
