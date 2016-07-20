using Miron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Miron.LojaVirtual.Web.Models;

namespace Miron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 8;  //3

        // GET: Vitrine
        public ViewResult ListaProdutos(string categoria, int pagina = 1)  //ActionResult
        {
            _repositorio = new ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            { 

                Produtos = _repositorio.Produtos
                    .Where(p => categoria == null || p.Categoria == categoria)
                    .OrderBy(p => p.Descricao)
                    .Skip((pagina - 1) * ProdutosPorPagina)
                    .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                  PaginaAtual = pagina,
                  ItensPorPagina = ProdutosPorPagina,
                  ItensTotal = _repositorio.Produtos.Count()
                },
                CategoriaAtual = categoria
            };
            
            
            return View(model);
        }
    }
}