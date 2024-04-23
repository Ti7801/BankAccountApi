
namespace BankAccountWebApi.Models
{
    public class Correntista
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email {  get; set; }
        public string Senha { get; set; }
        public List<ContaCorrente> ContaCorrente { get; private set; }

        public Correntista(string conta, string agencia, string nome, string cpf, string email,  string senha)
        {

            this.Nome = nome;
            this.Cpf = cpf;
            this.Email = email;
            this.Senha = senha;
            ContaCorrente = new List<ContaCorrente>();
        
        }
    }
}
