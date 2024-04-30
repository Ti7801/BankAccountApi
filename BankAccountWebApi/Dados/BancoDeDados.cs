using BankAccountWebApi.Models;

namespace BankAccountWebApi.Dados
{
    public class BancoDeDados
    {
        public List<Correntista> correntistas;

        public BancoDeDados() 
        {
            correntistas = new List<Correntista>(); 
        }

        public Correntista AdicionarCorrentista(Correntista novoCorrentista)
        {
            correntistas.Add(novoCorrentista);

            return novoCorrentista;
        }

        public List<Correntista> ObterCorrentistas()
        {
            return correntistas;
        }

        public Correntista? ObterCorrentistaPorId(Correntista novoCorrentista)
        {
            var correntista = correntistas.Where(correntista => correntista.Equals(novoCorrentista.Cpf)).SingleOrDefault();

            return correntista;
        }

        public Correntista? DeletarCorrentistaPorId(Correntista novoCorrentista)
        {
            var deletarCorrentista = correntistas.Where(deletarCorrentista => deletarCorrentista.Equals(novoCorrentista.Cpf)).SingleOrDefault();

            if (deletarCorrentista == null)
            {
                return null;
            }

            correntistas.Remove(deletarCorrentista);

            return deletarCorrentista;
        }

    }
}
