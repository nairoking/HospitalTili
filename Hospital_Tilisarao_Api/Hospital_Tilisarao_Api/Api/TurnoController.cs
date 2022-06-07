using Hospital_Tilisarao_Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Tilisarao_Api.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class TurnoController : ControllerBase
    {

        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public TurnoController(DataContext applicationDbContext, IConfiguration configuration)
        {
            this.contexto = applicationDbContext;
            this.config = configuration;
        }
        // GET: api/<TurnoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TurnoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("turnoPendiente")]
        public async Task<ActionResult<List<Turno>>> GetTurno()
        {

            try
            {

                var email = HttpContext.User.FindFirst(ClaimTypes.Name).Value;

                var paciente = await contexto.Paciente.FirstOrDefaultAsync(x => x.Email == email);

                var turnos = await contexto.Turno.Where(x => x.PacienteId == paciente.Id && x.Fecha> DateTime.Now).Include(x=> x.medico).ToListAsync();

              

                return turnos;


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());

            }




        }


        // POST api/<TurnoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Turno entidad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await contexto.Turno.AddAsync(entidad);
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = entidad.Id }, entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<TurnoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TurnoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
