using Boticario_api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boticario_api.Models
{
    public class InicializaDB
    {
        public static void Initialize(Context context)
        {
            context.Database.EnsureCreated();
            
            //init Revendedores
            if (context.Revendedores.Any())
            {
                return;
            }
            var revendedores = new Revendedor[]
            {
              new Revendedor{nome="Marcel", cpf="123.456.789-09", email="marcel@teste.com",senha="123456"}
            };
            foreach (Revendedor p in revendedores)
            {
                context.Revendedores.Add(p);
            }
            context.SaveChanges();
            
            
            //Init Compras
            if (context.Compras.Any())
            {
                return;
            }
            var compras = new Compra[]
            {
              new Compra{codigo="0000", valor=3.43, cpf="123.456.789-09"}
             };
            foreach (Compra p in compras)
            {
                context.Compras.Add(p);
            }
            context.SaveChanges();

        }
    }
}
