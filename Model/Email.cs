using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerProfile.Model
{
    public class Email
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(30, ErrorMessage = "Tamanho máximo é de 30 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        [Column("Email")]
        public string EndEmail { get; set; }
        [MaxLength(20,ErrorMessage = "Excedeu tamanho máximo de caracteres.")]
        [RegularExpression("([0-9]+)")]
        public string NroTelefone { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(300, ErrorMessage = "O limite de caracteres é de 300")]
        public string Mensagem { get; set; }
        public DateTime DataIncl { get; set; } = DateTime.Now;

    }
}
