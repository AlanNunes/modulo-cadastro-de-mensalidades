using Microsoft.VisualStudio.TestTools.UnitTesting;
using UGB_FINANCEIRO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGB_FINANCEIRO.Models.Tests
{
    [TestClass()]
    public class MensalidadeTests
    {
        [TestMethod()]
        public void CalculaValorPagarTest()
        {
            Mensalidade mensalidade = new Mensalidade()
            {
                ValorMensalidade = 1000,
                PercentualBolsa = 50,
                JurosAoDia = 1,
                DataVencimento = new DateTime(2018, 07, 10)
            };

            var valorEsperado = 500;
            var valorRecebido = mensalidade.CalculaValorPagar();

            Assert.AreEqual(valorEsperado, valorRecebido);
        }

        [TestMethod()]
        public void CalculaValorPagarTest2()
        {
            Mensalidade mensalidade = new Mensalidade()
            {
                ValorMensalidade = 2000,
                PercentualBolsa = 50,
                JurosAoDia = 1,
                DataVencimento = new DateTime(2018, 06, 10)
            };
            // Este valor é esperado se o código for rodado em 20/06/2018
            // Pois o método pega a data atual do sistema
            var valorEsperado = 2200;
            var valorRecebido = mensalidade.CalculaValorPagar();

            Assert.AreEqual(valorEsperado, valorRecebido);
        }
    }
}