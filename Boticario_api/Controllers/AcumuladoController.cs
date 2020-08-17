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

namespace Boticario_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcumuladoController : ControllerBase
    {
        private readonly Context _context;

        public AcumuladoController(Context context)
        {
            _context = context;
        }

        // GET: api/Acumulado
        [HttpGet]
        public async Task<ActionResult<Acumulado>> GetAcumulado()
        {
            HttpClient client = new HttpClient();
            Uri apiUri = new Uri("https://mdaqk8ek5j.execute-api.us-east-1.amazonaws.com/v1/cashback?cpf=12312312323");

            client.BaseAddress = apiUri;
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("token", "ZXPURQOARHiMc6Y0flhRC1LVlZQVFRnm");
            HttpResponseMessage response = client.GetAsync("").Result;

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Acumulado>();
            }
            else
            {
                return NotFound();
            }
            
        }
  
    }
}
