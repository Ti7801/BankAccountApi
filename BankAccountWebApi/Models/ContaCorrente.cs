namespace BankAccountWebApi.Models
{
    public class ContaCorrente
    {
        public string Numero { get; set; }
        public string Agencia { get; set; }
        public float Saldo { get; set; }
        public float Manutencao { get; set; }
        public int Length { get; }
        public Correntista Correntista { get; set; }
    

        public ContaCorrente(string numero, string agencia, float saldo,float manutencao, Correntista correntista) 
        {
            this.Numero = numero;
            this.Agencia = agencia;
            this.Saldo = saldo;
            this.Correntista = correntista;
        }

        public void Depositar(float saldo)
        {
            Saldo += saldo;
        }

        public float Sacar(float saldo)
        {
            if (PossoSacar(saldo))
            {
                Saldo -= saldo;
            }
            return Saldo;
        }

        public bool PossoSacar(float saldo)
        {
            if (Saldo < saldo)
            {
                return false;
            }
            return true;
        }

        public string AtualizarAgencia(string novaagencia)
        {
            if (AhAgenciaEhValida(novaagencia))
            {
                Agencia = novaagencia;
                return Agencia;
            }

            var aviso = "A agência não possui 7 caracteres";

            return aviso;       
        }

        public bool AhAgenciaEhValida(string tamanhoString)
        {
           var tamanho =  tamanhoString.Length;

            if (tamanho == 7)    // 12345-1
            {
                return true;
            }

            return false;
        }
    }
}
