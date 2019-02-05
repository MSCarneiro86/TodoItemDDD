using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using TodoItemDDD.Application.Interface;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Infra.Data.Contexto;
using TodoItemDDD.MVC.ViewModels;

namespace TodoItemDDD.MVC.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaAppService _categoriaApp;
        
        TodoItemDDDContext db = new TodoItemDDDContext();

        public CategoriasController(ICategoriaAppService categoriaApp)
        {
            _categoriaApp = categoriaApp;
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var categoriaViewModel = Mapper.Map<IEnumerable<Categoria>, IEnumerable<CategoriaViewModel>>(_categoriaApp.GetAll());
            return View(categoriaViewModel);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            var categoria = _categoriaApp.GetById(id);
            var categoriaViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);
            return View(categoriaViewModel);
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            ViewBag.Categorias = _categoriaApp.GetAll();

            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
               var categoriaDomain = Mapper.Map<Categoria>(categoriaViewModel);
                if(categoriaViewModel.CategoriaPaiId != null) { 
                var categoria = _categoriaApp.GetById(categoriaViewModel.CategoriaPaiId.Value);

                categoriaDomain.CategoriaPai = categoria;
                }
                _categoriaApp.Add(categoriaDomain);


                return RedirectToAction("Index");
            }

            ViewBag.Categorias = _categoriaApp.GetAll();
            return View(categoriaViewModel);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            var categoria = _categoriaApp.GetById(id);
            var categoriaViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);

            ViewBag.Categorias = _categoriaApp.GetAll();
            return View(categoriaViewModel);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel categoriaViewModel)
        {
            if (ModelState.IsValid)
            {
                var categoriaDomain = Mapper.Map<Categoria>(categoriaViewModel);
                if (categoriaViewModel.CategoriaPaiId != null)
                {
                    var categoria = _categoriaApp.GetById(categoriaViewModel.CategoriaPaiId.Value);

                    categoriaDomain.CategoriaPai = categoria;
                }

                _categoriaApp.Update(categoriaDomain);

                return RedirectToAction("Index");
            }
            ViewBag.Categorias = _categoriaApp.GetAll();
            return View(categoriaViewModel);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            var categoria = _categoriaApp.GetById(id);
            var categoriaViewModel = Mapper.Map<Categoria, CategoriaViewModel>(categoria);
            return View(categoriaViewModel);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var categoria = _categoriaApp.GetById(id);
            _categoriaApp.Remove(categoria);
            return RedirectToAction("Index");
        }

        
        

    }
}
