using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServerProfile.Data
{
    public class Email
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(30, ErrorMessage = "Tamanho máximo é de 30 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
        public string EndEmail { get; set; }
        [Required(ErrorMessage = "Campo obrigatório.")]
        [MaxLength(300, ErrorMessage = "O limite de caracteres é de 300")]
        public string Mensagem { get; set; } = "";
        
    }
}
