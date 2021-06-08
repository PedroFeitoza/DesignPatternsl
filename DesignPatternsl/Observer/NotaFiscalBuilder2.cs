using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsl.Observer;

namespace DesignPatternsl.Builder
{
    public class NotaFiscalBuilder2
    {
        public String RazaoSocial { get; set; }
        private String Cnpj { get; set; }
        private double ValorTotal { get; set; }
        private double Impostos { get; set; }
        private DateTime Data { get; set; }
        private String Observacoes { get; set; }

        private IList<ItemDaNota> TodosItens = new List<ItemDaNota>();

        private IList<AcaoAposGerarNota> todasAcoesASeremExecutadas;

        public NotaFiscalBuilder2()
        {
           todasAcoesASeremExecutadas = new List<AcaoAposGerarNota>();
        }

        public void AdicionaAcao(AcaoAposGerarNota novaAcao)
        {
           todasAcoesASeremExecutadas.Add(novaAcao);
        }

        public void VizualizaAcoes(NotaFiscal nf)
        {
            foreach (AcaoAposGerarNota acao in todasAcoesASeremExecutadas)
                acao.Executa(nf);
        }




        public NotaFiscal Constroi()
        {
            var nf = new NotaFiscal(RazaoSocial, Cnpj, Data, ValorTotal, Impostos, TodosItens, Observacoes);

            foreach (AcaoAposGerarNota acao in todasAcoesASeremExecutadas)
            {
                acao.Executa(nf);
            }

            return nf;
        }
        

        public NotaFiscalBuilder2 ParaEmpresa(String razaoSocial)
        {
            RazaoSocial = razaoSocial;
            return this;
        }

        public NotaFiscalBuilder2 ComCnpj(String cnpj)
        {
            Cnpj = cnpj;
            return this;
        }

        public NotaFiscalBuilder2 ComItem(ItemDaNota item)
        {
            TodosItens.Add(item);
            ValorTotal += item.Valor;
            Impostos += item.Valor * 0.05;
            return this;
        }

        public NotaFiscalBuilder2 ComObservacoes(String observacoes)
        {
            Observacoes = observacoes;
            return this;
        }

        public NotaFiscalBuilder2 NaDataAtual()
        {
            Data = DateTime.Now;
            return this;
        }

    }
}
