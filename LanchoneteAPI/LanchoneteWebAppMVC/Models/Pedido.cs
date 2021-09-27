using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteAPI.Model
{
    public class Pedido
    {

        public int Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Lanche Lanche { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Clientes { get; set; }

        [NotMapped]
        public virtual List<SelectListItem> Lanches { get; set; }




    }
}
