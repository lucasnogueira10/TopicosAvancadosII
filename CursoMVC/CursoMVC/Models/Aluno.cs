using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CursoMVC.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        [DisplayName("Nome da Imagem")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Imagem")]
        public virtual IFormFile ImageFile { get; set; }
    }
}
