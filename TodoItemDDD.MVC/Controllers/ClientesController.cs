using System.Collections.Generic;
using AutoMapper;
using System.Web.Mvc;
using TodoItemDDD.MVC.ViewModels;
using TodoItemDDD.Domain.Entities;
using TodoItemDDD.Application.Interface;

namespace TodoItemDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IEnderecoAppService _enderecoApp;

        public ClientesController(IClienteAppService clienteApp, IEnderecoAppService enderecoApp)
        {
            _clienteApp = clienteApp;
            _enderecoApp = enderecoApp;
        }
        
        // GET: Clientes
        public ActionResult Index()
        {
            var clienteViewModel = Mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());
            return View(clienteViewModel);
        }
        
        // GET: Clientes/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        // GET: Clientes/Create
        public ActionResult Cadastrar()
        {
            return View();
        }

        // POST: Clientes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<Cliente> (clienteEnderecoViewModel.ClienteViewModel);
                var enderecoDomain = Mapper.Map<Endereco>(clienteEnderecoViewModel.EnderecoViewModel);

             
                clienteDomain.Endereco = enderecoDomain;
                _clienteApp.Add(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int id)
        {

            var cliente = _clienteApp.GetById(id);
            var ClienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
           
            return View(ClienteViewModel);
        }

        // POST: Clientes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteEnderecoViewModel clienteEnderecoViewModel)
        {
            if (ModelState.IsValid)
            {
                var clienteDomain = Mapper.Map<Cliente>(clienteEnderecoViewModel.ClienteViewModel);
                var enderecoDomain = Mapper.Map<Endereco>(clienteEnderecoViewModel.EnderecoViewModel);

                clienteDomain.Endereco = enderecoDomain;

                _clienteApp.Update(clienteDomain);

                return RedirectToAction("Index");
            }

            return View(clienteEnderecoViewModel);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = Mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
            
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cliente = _clienteApp.GetById(id);
            _clienteApp.Remove(cliente);
            return RedirectToAction("Index");
        }
    }
}
