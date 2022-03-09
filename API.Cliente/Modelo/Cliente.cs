using System.ComponentModel.DataAnnotations;
using Xunit;

namespace API.Cliente.Modelo
{
    public class ClienteModelo
    {
        public string Nome { get; set; }  
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O sobrenome é obrigatório!")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O CPF é obrigatório!")]
        public DateTime DataDeNascimento { get; set; }
        


        public ClienteModelo()
        {
        }
        public ClienteModelo (string nome, string sobrenome, string cpf, DateTime dataDeNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Cpf = cpf;
            DataDeNascimento = dataDeNascimento;
        }

      



    }
}
