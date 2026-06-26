using Microsoft.AspNetCore.Mvc;
using Imobiliaria.Repositories;
using Imobiliaria.Models;

namespace Imobiliaria.Controllers
{
    public class ImoveisController : Controller
    {
        private readonly ImovelRepository _repository;

        public ImoveisController(IConfiguration config)
        {
            _repository = new ImovelRepository(config);
        }

        public IActionResult Index()
        {
            var imoveis = _repository.ListarTodos();
            return View(imoveis);
        }

        [HttpGet]
        public JsonResult FiltrarPorBairro(string bairro)
        {
            var dados = _repository.ListarTodos(bairro);
            return Json(dados);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Imovel imovel)
        {
            _repository.Inserir(imovel);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var imovel = _repository.ObterPorId(id);
            if (imovel == null) return NotFound();
            return View(imovel);
        }

        [HttpPost]
        public IActionResult Edit(Imovel imovel)
        {
            _repository.Atualizar(imovel);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public JsonResult DeleteAjax(int id)
        {
            try
            {
                _repository.Excluir(id);
                return Json(new { success = true });
            }
            catch
            {
                return Json(new { success = false });
            }
        }
    }
}