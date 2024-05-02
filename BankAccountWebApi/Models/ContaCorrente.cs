using System.ComponentModel.DataAnnotations;

namespace BankAccountWebApi.Models
{
    public class ContaCorrente
    {
        [Required]
        public string? Numero { get; set; }

        [Required]
        public string? Agencia { get; set; }
        
        public float? Saldo { get; set; }
      
        public float? Manutencao { get; set; }
  
        //private int? Length { get; }

        [Required]
        public int Correntista_id { get; set; } 

        public ContaCorrente() 
        {

        }

        public void Depositar(float saldo)
        {
            Saldo += saldo;
        }

        public float? Sacar(float saldo)
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
