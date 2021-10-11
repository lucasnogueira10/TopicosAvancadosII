using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarControWebApp.Models
{
    public class Car
    {
        public int Id { get; set; }

        [DisplayName("Nome")]
        public string Name { get; set; }

        [DisplayName("Cor")]
        public string Color { get; set; }

        [DisplayName("Ano")]
        public DateTime Year { get; set; }

        [DisplayName("Modelo")]
        public string Model { get; set; }

        [DisplayName("Cidade")]
        public string City { get; set; }

        [DisplayName("Valor")]
        public decimal Value { get; set; }

        [DisplayName("Potência")]
        public string Power { get; set; }

        [DisplayName("Quantidade de Portas")]
        public int NumberOfDoors { get; set; }

        [DisplayName("Nome da Imagem")]
        public string Image { get; set; }

        [NotMapped]
        [DisplayName("Imagem do Carro")]
        public IFormFile CarPicture { get; set; }
    }
}
