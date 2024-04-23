using Microsoft.AspNetCore.Mvc;
using BankAccountWebApi.Models;
using BankAccountWebApi.Dados;

namespace BankAccountWebApi.Controllers
{
    public class ContaCorrenteController : ControllerBase
    {

        public readonly BancoDeDados banco;


        public ContaCorrenteController(BancoDeDados banco)
        {
            this.banco = banco;
        }



    }
}
