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

        public Correntista? ObterCorrentistaPorCpf(string? cpf)
        {
            var correntista = correntistas.Where( v => v.Cpf == cpf).SingleOrDefault();

            return correntista;
        }

        public Correntista? DeletarCorrentistaPorCpf(string? cpf)
        {
            var deletarCorrentista = correntistas.Where(v => v.Cpf == cpf).SingleOrDefault();

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

        public ContaCorrente? ObterContaCorrentePorId(int correntista_id)
        {
            var novaContaCorrente = contasCorrentes.Where(v => v.Correntista_id == correntista_id).SingleOrDefault();

            return novaContaCorrente;
        }

        public ContaCorrente? DeletarContaCorrentePorId(int correntista_id)
        {
            var DeletarContaCorrente = ObterContaCorrentePorId(correntista_id);

            if (DeletarContaCorrente == null)
            {
                return null;
            }

            contasCorrentes.Remove(DeletarContaCorrente);

            return DeletarContaCorrente;
        }


    }
}
