using Boticario_api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario_api.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
       
        public DbSet<Revendedor> Revendedores { get; set; }
        public DbSet<Compra> Compras { get; set; }
    }
}
