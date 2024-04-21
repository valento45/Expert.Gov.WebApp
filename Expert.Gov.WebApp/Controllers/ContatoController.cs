using Expert.Gov.Core.Models.SolicitacaoSugestao;
using Expert.Gov.Core.Models.TrabalhosRealizados;
using Expert.Gov.Core.Services.Interfaces;
using Expert.Gov.WebApp.Applications.Interfaces;
using Expert.Gov.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace Expert.Gov.WebApp.Controllers
{
    public class ContatoController : Controller
    {
        private readonly ISolicitacaoApplication _solicitacaoApplication;

        public ContatoController(ISolicitacaoApplication solicitacaoApplication)
        {
            _solicitacaoApplication = solicitacaoApplication;
        }

        //[HttpGet]
        //public async Task<IActionResult> SolicitarMelhorias()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> SolicitarMelhorias()
        {


            var solicitacaoLista_ = new SolicitacoesLista();

            solicitacaoLista_.ListaSolicitacoes = await _solicitacaoApplication.ObterTodasSolicitacaoes(new Solicitacao());



            return View(solicitacaoLista_);
        }

        [HttpGet]
        public async Task<IActionResult> InserirSolicitacao()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> InserirSolicitacao(SolicitacaoViewModel solicitacao)
        {

            var result = await _solicitacaoApplication.InserirSolicitacao(solicitacao);

            return Json(result);
        }


        [HttpPost]
        public async Task<IActionResult> SalvarSolicitacao(SolicitacaoViewModel solicitacaoViewModel)
        {


            if (solicitacaoViewModel.Id_Solicitacao > 0)
            {
                Solicitacao solicitacao = new Solicitacao();

                solicitacao.Id_Solicitacao = solicitacaoViewModel.Id_Solicitacao;
                solicitacao.Nome = solicitacaoViewModel.Nome;
                solicitacao.Celular = solicitacaoViewModel.Celular;
                solicitacao.Email = solicitacaoViewModel.Email;
                solicitacao.Endereco_solicitacao = solicitacaoViewModel.Endereco_solicitacao;
                solicitacao.Numero_solicitacao = solicitacaoViewModel.Numero_solicitacao;
                solicitacao.Cep_solicitacao = solicitacaoViewModel.Cep_solicitacao;
                solicitacao.Descricao_Titulo = solicitacaoViewModel.Descricao_Titulo;
                solicitacao.Descricao_Sugestao_Melhoria = solicitacaoViewModel.Descricao_Sugestao_Melhoria;

                await _solicitacaoApplication.AtualizarSolicitacao(solicitacao);
            }
            else
            {
                await _solicitacaoApplication.InserirSolicitacao(solicitacaoViewModel);
            }
            return Ok(true);

        }

        public async Task<IActionResult> ExcluirAnexo(long Id_Solicitacao)
        {
            var result = await _solicitacaoApplication.ExcluirAnexo(Id_Solicitacao);

            return RedirectToAction(nameof(SolicitarMelhorias));
        }

        public async Task<IActionResult> ExcluirSolicitacao(long id)
        {
            var result = await _solicitacaoApplication.ExcluirSolicitacao(id);

            return RedirectToAction(nameof(SolicitarMelhorias));
        }



        //[HttpGet]
        //public async Task<IActionResult> VerSolicitacoesRecebidas()
        //{
        //    var solicitacoes = await _solicitacaoApplication.ConsultarSolicitacoes();
        //    return View(solicitacoes);
        //}

    }
}
