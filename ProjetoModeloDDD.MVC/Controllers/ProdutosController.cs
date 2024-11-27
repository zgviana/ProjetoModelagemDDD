﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        // GET: Produtos
        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        private MapperConfiguration configProdutoToProdutoViewModel = new MapperConfiguration(cfg =>
              cfg.CreateMap<Produto, ProdutoViewModel>());

        private MapperConfiguration configViewModelToProduto = new MapperConfiguration(cfg =>
                    cfg.CreateMap<ProdutoViewModel, Produto>());

        public ProdutosController(IProdutoAppService produtoApp, IClienteAppService clienteApp)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            Mapper mapper = new Mapper(configProdutoToProdutoViewModel);
            var produtoViewModel = mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());

            return View(produtoViewModel);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            Mapper mapper = new Mapper(configProdutoToProdutoViewModel);
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                Mapper mapper = new Mapper(configViewModelToProduto);
                var produtoDomain = mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            Mapper mapper = new Mapper(configProdutoToProdutoViewModel);
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = mapper.Map<Produto, ProdutoViewModel>(produto);

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                Mapper mapper = new Mapper(configViewModelToProduto);
                var produtoDomain = mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            Mapper mapper = new Mapper(configProdutoToProdutoViewModel);
            var produto = _produtoApp.GetById(id);
            var produtoViewModel = mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // POST: Cliente/Delete/5
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
