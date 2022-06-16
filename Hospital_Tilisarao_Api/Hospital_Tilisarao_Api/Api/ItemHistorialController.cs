using Hospital_Tilisarao_Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Tilisarao_Api.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ItemHistorialController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public ItemHistorialController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }
        // GET: api/<ItemHistorialController>
        [HttpGet]
        public async Task<ActionResult<List<ItemHistorial>>> Get()
        {
            var usuario = User.Identity.Name;
            var paciente = await contexto.Paciente.SingleOrDefaultAsync(x => x.Email == usuario);
            var historial = await contexto.Historial.SingleOrDefaultAsync(x => x.PacienteId == paciente.Id);

            return await contexto.ItemHistorial.Where(x => x.HistorialId == historial.Id).Include(x => x.Medico).ToListAsync();
        }


        // GET api/<ItemHistorialController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemHistorialController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemHistorialController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemHistorialController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
