using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using Miron.LojaVirtual.Web.HtmlHelpers;
using Miron.LojaVirtual.Web.Models;

namespace Miron.LojaVirtual.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Take()
        {
            //O operador é usado para selecionar os primeiros n objetos de uma coleção

            int[] numeros = {5, 4, 1, 3, 9, 8, 6, 7, 2, 0};

            var resultado = from num in numeros.Take(5) select num;

            int[] teste = {5, 4, 1, 3, 9};

            CollectionAssert.AreEqual(resultado.ToArray(), teste);
        }

        [TestMethod]
        public void Skip()
        {
            // O operador Skip ignora o (s) primeiro(s) n objetos de uma coleção.

            int[] numeros = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var resultado = from num in numeros.Take(5).Skip(5) select num;
        }
        [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange

            HtmlHelper htmlHelper = null;

            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };

            Func<int, string> paginaUrl = i => "Pagina" + i;

            //Act

            MvcHtmlString resultado = htmlHelper.PageLinks(paginacao, paginaUrl);

            //Assert

            Assert.AreEqual(

                  @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()

                );

        }
    }
}
