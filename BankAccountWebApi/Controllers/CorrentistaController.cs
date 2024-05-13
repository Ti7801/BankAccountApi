using Microsoft.AspNetCore.Mvc;
using BankAccountWebApi.Models;
using BankAccountWebApi.Dados;
using System;

namespace BankAccountWebApi.Controllers
{
    [ApiController]
    [Route("correntista")]
    public class CorrentistaController : ControllerBase
    {
        public readonly AppDbContext appDbContext;
        public readonly BancoDeDados banco;

        public CorrentistaController(AppDbContext appDbContext, BancoDeDados banco)
        {
            this.appDbContext = appDbContext;
            this.banco = banco;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Correntista), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Correntista> CriarCorrentista(Correntista novocorrentista)
        {
            var correntista = banco.AdicionarCorrentista(novocorrentista);
        

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(errors => errors.ErrorMessage);

                return BadRequest(errors);
            }

            return CreatedAtAction(actionName:nameof(CriarCorrentista), correntista);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Correntista>> ListarCorrentistas()
        {
            var lista = banco.ObterCorrentistas();

            return Ok(lista);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Correntista), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Correntista> AtualizarCorrentista(Correntista novoCorrentista)
        {
            var correntista = banco.ObterCorrentistaPorCpf(novoCorrentista.Cpf);

            if (correntista == null)
            {
                return NotFound(correntista);
            }

            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(erros => erros.ErrorMessage);
                return BadRequest(erros);
            }

            correntista.Nome = novoCorrentista.Nome;
            correntista.Cpf = novoCorrentista.Cpf;
            correntista.Email = novoCorrentista.Email;
            correntista.Senha = novoCorrentista.Senha;

            return Ok(correntista);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Correntista?> DeletarCorrentista(Correntista novoCorrentista)
        {
            var correntistaDeletado = banco.DeletarCorrentistaPorCpf(novoCorrentista.Cpf);
            
            return Ok(correntistaDeletado);
        }
    }
}
