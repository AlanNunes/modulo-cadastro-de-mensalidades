namespace UGB_FINANCEIRO.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Mensalidade")]
    public partial class Mensalidade
    {
        [Key]
        public int idMensalidade { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:0.00}")]
        [Display(Name = "Valor Mensalidade")]
        public int ValorMensalidade { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data Vencimento")]
        public DateTime DataVencimento { get; set; }

        [Display(Name = "%Juros/Dia")]
        public int JurosAoDia { get; set; }

        [Display(Name = "% Bolsa")]
        public int PercentualBolsa { get; set; }

        public int? Curso_idCurso { get; set; }

        public virtual Curso Curso { get; set; }

        // Calcula o Valor a Pagar
        //
        // Atributos
        //
        // int ValorMensalidade Mensalidade
        // DateTime DataVencimento Data de Vencimento da Mensalidade
        // int PercentualBolsa Porcentagem da Bolsa
        // int JurosAoDia Juros/Dia
        //
        // Descrição do Processo
        //
        // Calcula a diferença da data atual do sistema com a data de vencimento da mensalidade
        // exemplo: (hoje - dtVencimento). Afim de obter a diferença em dias
        // Se a diferença em dias for negativa ou positiva, significa que o cliente pagou com 
        // antecendência e então a mensalidade recebe o valor do desconto da bolsa
        // exemplo: (mensalidade*(bolsa/100))
        // Caso a diferença em dias seja superior à 0, o valor da bolsa não é incluido no 
        // cálculo e os juros são aplicados à mensalidade de acordo com a quantidade de dias de
        // atrasos. Exemplo: mensalidade + (mensalidade * ((juros / 100) * diferenca))
        //
        // return Retorna o valor a ser pago da mensalidade
        public double CalculaValorPagar()
        {
            DateTime dataAtual = DateTime.Today;
            // Calcula a diferença de dias
            var dias = (dataAtual - this.DataVencimento).TotalDays;
            double valorTotal = 0;

            if (dias > 0)
            {
                // Aplica juros à mensalidade pois o cliente atrasou a mensalidade
                valorTotal = Convert.ToDouble(this.ValorMensalidade) + 
                    (Convert.ToDouble(this.ValorMensalidade) * ((Convert.ToDouble(this.JurosAoDia) / 100) * dias));
            }
            else
            {
                // Calcula a mensalidade com a bolsa pois o cliente pagou in time
                valorTotal = Convert.ToDouble(this.ValorMensalidade) - (Convert.ToDouble(this.ValorMensalidade) 
                    * (Convert.ToDouble(this.PercentualBolsa) / 100));
            }
            return valorTotal;
        }
    }
}
