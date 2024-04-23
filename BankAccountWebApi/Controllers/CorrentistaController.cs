using Microsoft.AspNetCore.Mvc;
using BankAccountWebApi.Models;
using BankAccountWebApi.Dados;

namespace BankAccountWebApi.Controllers
{
    public class CorrentistaController : ControllerBase
    {
        public readonly BancoDeDados banco;

        public CorrentistaController(BancoDeDados banco)
        {
            this.banco = banco;
        }



    }
}
