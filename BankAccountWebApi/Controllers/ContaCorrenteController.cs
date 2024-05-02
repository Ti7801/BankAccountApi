using Microsoft.AspNetCore.Mvc;
using BankAccountWebApi.Models;
using BankAccountWebApi.Dados;

namespace BankAccountWebApi.Controllers
{
    [ApiController]
    [Route("contaCorrente")]
    public class ContaCorrenteController : ControllerBase
    {

        public readonly BancoDeDados banco;


        public ContaCorrenteController(BancoDeDados banco)
        {
            this.banco = banco;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ContaCorrente), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ContaCorrente>  CriarContaCorrente(ContaCorrente contaCorrente)
        {
            banco.AdicionarContaCorrente(contaCorrente);

            if (!ModelState.IsValid) 
            {
                var erros = ModelState.Values.SelectMany(v => v.Errors).Select(erros => erros.ErrorMessage);
                return BadRequest(erros);
            }

            return CreatedAtAction(actionName: nameof(CriarContaCorrente), contaCorrente);
        }



    }
}
