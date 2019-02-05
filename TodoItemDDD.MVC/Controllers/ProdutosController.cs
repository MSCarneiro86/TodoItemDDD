using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using TodoItemDDD.Application.Interface;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Infra.Data.Contexto;
using TodoItemDDD.MVC.ViewModels;

namespace TodoItemDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IProdutoAppService _produtoApp;

        private readonly IClienteAppService _clienteApp;

        private readonly ICategoriaAppService _categoriaApp;

        public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp, ICategoriaAppService categoriaApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
            _categoriaApp = categoriaApp;
        }

        // GET: Produtos
        public ActionResult Index()
        {
            //var produto = db.Set<Produto>().ToList();
            var produto = _produtoApp.GetAll();

            return View(produto);
            
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produtoViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            var categorias = new List<Categoria>();
            Session["Clientes"] = new SelectList(_clienteApp.GetAll(), "ClienteId", "RazaoSocial");
            
            ViewBag.Categorias = new SelectList(_categoriaApp.GetAll(), "CategoriaId", "NomeCategoria");

            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto, HttpPostedFileBase file)
        {
            var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
            ViewBag.Categorias = new SelectList(_categoriaApp.GetAll(), "CategoriaId", "NomeCategoria");
           
            var  categoriaSelected = Request.Form["chkCategorias"];

            if (!string.IsNullOrEmpty(categoriaSelected))
            {
                int[] splCategorias = categoriaSelected.Split(',').Select(Int32.Parse).ToArray();

                if (splCategorias.Count() > 0)
                {
                   //var categoria = db.Categorias.Where(w => splCategorias.Contains(w.CategoriaId)).ToList();
                   var categoria = _produtoApp.ListarCategorias(splCategorias).ToList();
                        produtoDomain.Categorias.AddRange(categoria);
                    }
             }
            
                if (file != null)
                {
                    String[] strName = file.FileName.Split('.');
                    String strExt = strName[strName.Count() - 1];
                    string pathSave = String.Format("{0}{1}.{2}", Server.MapPath("~/Images/Produtos/"), produtoDomain.ProdutoId, strExt);
                    String pathBase = String.Format("/Images/Produtos/{0}.{1}", produtoDomain.ProdutoId, strExt);
                    file.SaveAs(pathSave);

                    produtoDomain.Imagem = pathBase;
                    _produtoApp.Add(produtoDomain);
                    return RedirectToAction("Index");
                }
            

            return View(produto);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {

            Produto produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produtoViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);

        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            return View(produtoViewModel);

        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetById(id);
            _produtoApp.Remove(produto);
            return RedirectToAction("Index");
        }

    }
}