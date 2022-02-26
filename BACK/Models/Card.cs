using System;
using System.ComponentModel.DataAnnotations;

namespace BACK.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este campo deve conter entre 3 e 250 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 250 caracteres")]
        public string Conteudo { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Lista { get; set; }
    }
}