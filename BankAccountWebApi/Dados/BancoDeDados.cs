using BankAccountWebApi.Models;

namespace BankAccountWebApi.Dados
{
    public class BancoDeDados
    {
        public List<Correntista> correntistas;
        public List<ContaCorrente> contasCorrentes;

        public BancoDeDados() 
        {
            correntistas = new List<Correntista>(); 
            contasCorrentes = new List<ContaCorrente>();
        }

        // CORRENTISTA

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

        // CONTA CORRENTE

        public ContaCorrente AdicionarContaCorrente(ContaCorrente contaCorrente)
        {
            contasCorrentes.Add(contaCorrente);

            return contaCorrente;
        }
       
        public List<ContaCorrente> ObterContasCorrentes()
        {
            return contasCorrentes; 
        }

        public ContaCorrente? ObterContaCorrentePorId(ContaCorrente contaCorrente)
        {
            var novaContaCorrente = contasCorrentes.Where(novaContaCorrente => novaContaCorrente.Equals(contaCorrente.Correntista_id)).SingleOrDefault();

            return novaContaCorrente;
        }

        public ContaCorrente? DeletarContaCorrentePorId(ContaCorrente contaCorrente)
        {
            var DeletarContaCorrente = ObterContaCorrentePorId(contaCorrente);

            if (DeletarContaCorrente == null)
            {
                return null;
            }

            contasCorrentes.Remove(DeletarContaCorrente);

            return DeletarContaCorrente;
        }


    }
}
