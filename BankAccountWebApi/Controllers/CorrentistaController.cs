using Microsoft.AspNetCore.Mvc;
using BankAccountWebApi.Models;
using BankAccountWebApi.Dados;


namespace BankAccountWebApi.Controllers
{
    [ApiController]
    [Route("correntista")]
    public class CorrentistaController : ControllerBase
    {
        public readonly AppDbContext appDbContext;

        public CorrentistaController(AppDbContext appDbContext)
        {
           this.appDbContext = appDbContext;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Correntista), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Correntista> CriarCorrentista(Correntista novocorrentista)
        {
            appDbContext.CorrentistasBanco.Add(novocorrentista);
            appDbContext.SaveChanges();
        

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(errors => errors.ErrorMessage);

                return BadRequest(errors);
            }

            return CreatedAtAction(actionName:nameof(CriarCorrentista), novocorrentista);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Correntista>> ListarCorrentistas()
        {
           var lista = appDbContext.CorrentistasBanco;

            return Ok(lista);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Correntista), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Correntista> AtualizarCorrentista(Correntista novoCorrentista)
        {

            var correntista = appDbContext.CorrentistasBanco.Where(u => u.Id == novoCorrentista.Id).SingleOrDefault();

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

            appDbContext.CorrentistasBanco.Update(correntista);
            appDbContext.SaveChanges();

            return Ok(correntista);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Correntista> DeletarCorrentista(Correntista  novoCorrentista)
        {
            var correntistaDeletado = appDbContext.CorrentistasBanco.Where(u => u.Id == novoCorrentista.Id).SingleOrDefault();

            if (correntistaDeletado == null)
            {
                return NotFound(correntistaDeletado);
            }

            appDbContext.CorrentistasBanco.Remove(correntistaDeletado);
            appDbContext.SaveChanges();

            return Ok(correntistaDeletado);
        }
    }
}
