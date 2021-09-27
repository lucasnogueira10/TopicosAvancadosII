using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteAPI.Model
{
    public class Pedido
    {

        public int Id { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Lanche Lanche { get; set; }

    }
}
