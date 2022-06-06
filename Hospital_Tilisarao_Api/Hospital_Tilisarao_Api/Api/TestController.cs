using Hospital_Tilisarao_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Tilisarao_Api.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataContext Contexto;

        public TestController(DataContext dataContext)
        {
            this.Contexto = dataContext;
        }

        // GET: api/<TestController>
        [HttpGet]
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(new
                {
                    Mensaje = "Éxito",
                    Error = 0,
                    Resultado = new
                    {
                        Clave = "Key",
                        Valor = new Random().Next(0, 10000)
                    },
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // GET api/<TestController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(Contexto.Paciente.Find(id));
        }

        [HttpGet("medico/{id}")]
        public IActionResult GetMedico(int id)
        {
            return Ok(Contexto.Medico.Find(id));
        }
        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
