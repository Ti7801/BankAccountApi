using System.ComponentModel.DataAnnotations;

namespace BankAccountWebApi.Models
{
    public class Correntista
    {
        public string? Nome { get; set; }

        [Required(ErrorMessage = "CPF é um campo obrigatório!")]
        [StringLength(11, ErrorMessage = "CPF deve conter 11 digitos!")]
        public string? Cpf { get; set; }

        public string? Email {  get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório!")]
        [StringLength(6, ErrorMessage = "A senha deve conter 6 digitos!")]
        public string? Senha { get; set; }

        //public List<ContaCorrente> ContaCorrente { get; private set; }


        public Correntista()
        {
            //ContaCorrente = new List<ContaCorrente>();    
        }



    }
}
