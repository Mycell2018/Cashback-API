using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario_api.Models
{
    public class Compra
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string codigo { get; set; }
        public Double valor { get; set; }
        public DateTime data { get; set; } = DateTime.Now;
        public string cpf { get; set; }
        public string cashbackPorcentagem { get; set; } = "0%";
        public Double cashbackValor { get; set; }
        public string status { get; set; } = "Em validação";
    }
}
