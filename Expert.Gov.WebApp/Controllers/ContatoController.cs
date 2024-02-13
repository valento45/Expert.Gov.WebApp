using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ISolicitacaoService _solicitacaoService;

        public ContatoController(ISolicitacaoService solicitacaoService)
        {
            _solicitacaoService = solicitacaoService;
        }

        [HttpGet]
        public async Task<IActionResult> SolicitarMelhorias()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> IncluirSolicitacao(Solicitacao solicitacao)
        {
            var result = await _solicitacaoService.Inserir(solicitacao);

            return Json(result);
        }


        [HttpGet]
        public async Task<IActionResult> VerSolicitacoesRecebidas()
        {
            var solicitacoes = await _solicitacaoService.ConsultarSolicitacoes();
            return View(solicitacoes);
        }

    }
}
