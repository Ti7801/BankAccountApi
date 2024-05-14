using Microsoft.AspNetCore.Mvc;
using BankAccountWebApi.Models;
using BankAccountWebApi.Dados;

namespace BankAccountWebApi.Controllers
{
    [ApiController]
    [Route("contaCorrente")]
    public class ContaCorrenteController : ControllerBase
    {

        public readonly AppDbContext appDbContext;

        public ContaCorrenteController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContaCorrente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ContaCorrente>  CriarContaCorrente(ContaCorrente contaCorrente)
        {
            appDbContext.ContaCorrenteBanco.Add(contaCorrente);
            appDbContext.SaveChanges();
            
           
            if (!ModelState.IsValid) 
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(erros => erros.ErrorMessage);
                return BadRequest(erros);
            }

            return CreatedAtAction(actionName: nameof(CriarContaCorrente), contaCorrente);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<ContaCorrente>> ListarContaCorrente() 
        {
            var lista = appDbContext.ContaCorrenteBanco;

            return Ok(lista);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ContaCorrente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ContaCorrente>? AtualizarContaCorrente(ContaCorrente contaCorrenteNova)
        {
            var contaCorrenteAntiga = appDbContext.ContaCorrenteBanco.Where(u => u.Correntista_id == contaCorrenteNova.Correntista_id).SingleOrDefault();

            if (contaCorrenteAntiga == null)
            {
                return null;
            }

            if (!ModelState.IsValid)
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(erros => erros.ErrorMessage);
                return BadRequest(erros);
            }

            contaCorrenteAntiga.Numero = contaCorrenteNova.Numero;
            contaCorrenteAntiga.Agencia = contaCorrenteNova.Agencia;
            contaCorrenteAntiga.Saldo = contaCorrenteNova.Saldo;    
            contaCorrenteAntiga.Manutencao = contaCorrenteNova.Manutencao;
            contaCorrenteAntiga.Correntista_id = contaCorrenteNova.Correntista_id;

            appDbContext.ContaCorrenteBanco.Update(contaCorrenteAntiga);
            appDbContext.SaveChanges();

            return Ok(contaCorrenteAntiga);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ContaCorrente> DeletarContaCorrente(ContaCorrente contaCorrente)
        {         
            var contaCorrenteDeletada = appDbContext.ContaCorrenteBanco.Where(u => u.Correntista_id == contaCorrente.Correntista_id).SingleOrDefault();

            if (contaCorrenteDeletada == null)
            {
                return BadRequest();   
            }

            appDbContext.ContaCorrenteBanco.Remove(contaCorrenteDeletada);
            appDbContext.SaveChanges();

            return Ok(contaCorrenteDeletada);
        }
    }
}
