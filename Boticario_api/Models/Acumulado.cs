using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario_api.Models
{
    public class Acumulado
    {
        public int statusCode { get; set; }
        public Body body { get; set; }

    }
    public class Body
    {
        public Double credit { get; set; }
    }
}
