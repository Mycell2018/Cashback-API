using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Boticario_api.Data;
using Boticario_api.Models;
using Boticario_api.Utils;
using System.Globalization;
using Google.Protobuf.WellKnownTypes;
using System.Net.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace Boticario_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        // GET: api/Acumulado
        [HttpGet]
        public async Task<ActionResult<Revendedor>> GetLogin(string email, string password)
        {
            var revendedor = await _context.Revendedores.Where(r => r.email.Equals(email) && r.senha.Equals(password)).FirstOrDefaultAsync();

            if (revendedor == null)
            {
                return NotFound();
            }

            //TODO: falta implementar JWT

            return revendedor;
        }
       
    }
}
