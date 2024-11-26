using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;
using System.Collections;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteAppService _clienteApp;

        public ClientesController(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;            
        }

        private MapperConfiguration configClienteToClienteViewModel = new MapperConfiguration(cfg =>
               cfg.CreateMap<Cliente, ClienteViewModel>());

        private MapperConfiguration configViewModelToCliente = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ClienteViewModel, Cliente>());

        // GET: ClientesController
        public ActionResult Index()        {

            Mapper mapper = new Mapper(configClienteToClienteViewModel);

            var clienteViewModel = mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.GetAll());

            return View(clienteViewModel);
        }
        public ActionResult Especiais()
        {
            Mapper mapper = new Mapper(configClienteToClienteViewModel);
            var clienteViewModel = mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClienteEspeciais());
            return View(clienteViewModel);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            Mapper mapper = new Mapper(configClienteToClienteViewModel);
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = mapper.Map<Cliente,ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {                   
                    
                    Mapper mapper = new Mapper(configViewModelToCliente);
                    var clienteDomain = mapper.Map<ClienteViewModel, Cliente>(cliente);
                    _clienteApp.Add(clienteDomain);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            Mapper mapper = new Mapper(configClienteToClienteViewModel);
            var cliente = _clienteApp.GetById(id);
            var clienteViewModel = mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper mapper = new Mapper(configViewModelToCliente);
                    var clienteDomain = mapper.Map<ClienteViewModel, Cliente>(cliente);
                    _clienteApp.Update(clienteDomain);
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            catch
            {
                return View(cliente);
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {            
            Cliente c = new Cliente();
            c = _clienteApp.GetById(id);
            _clienteApp.Remove(c);
            return RedirectToAction("Index");          
        }

        // POST: ClientesController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
