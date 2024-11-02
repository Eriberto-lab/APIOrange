using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(8)]
        public string Senha { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required, Phone]
        public string Telefone { get; set; }

        [Required]
        public string NomeCompleto { get; set; }

        public string Tipo { get; set; }
    }
}
