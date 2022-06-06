using Hospital_Tilisarao_Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hospital_Tilisarao_Api.Api
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public PacienteController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }


        // GET: api/<PacienteController>
        [HttpGet]
        public async Task<ActionResult<Paciente>> Get()
        {
            try
            {
                
                var usuario = User.Identity.Name;
               
                return await contexto.Paciente.SingleOrDefaultAsync(x => x.Email == usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        // POST api/<controller>/login
        [HttpPost("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] LoginView loginView)
		{
			try
			{
				/*string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
					password: loginView.Clave,
					salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
					prf: KeyDerivationPrf.HMACSHA1,
					iterationCount: 1000,
					numBytesRequested: 256 / 8));*/
				string hashed = loginView.Clave;
				var p = await contexto.Paciente.FirstOrDefaultAsync(x => x.Email == loginView.Usuario);
				if (p == null || p.Clave != hashed)
				{
					return BadRequest("Nombre de usuario o clave incorrecta");
				}
				else
				{
					var key = new SymmetricSecurityKey(
						System.Text.Encoding.ASCII.GetBytes(config["TokenAuthentication:SecretKey"]));
					var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

					var claims = new List<Claim>
					{
						new Claim(ClaimTypes.Name,p.Email),
						new Claim("FullName", p.Nombre + " " + p.Apellido),
						new Claim(ClaimTypes.Role, "Paciente"),
					};

					var token = new JwtSecurityToken(
						issuer: config["TokenAuthentication:Issuer"],
						audience: config["TokenAuthentication:Audience"],
						claims: claims,
						expires: DateTime.Now.AddMinutes(60),
						signingCredentials: credenciales
					);
					return Ok(new JwtSecurityTokenHandler().WriteToken(token));
				}
			}
			catch (Exception ex)
			{
				return BadRequest(ex);
			}
		}

		// GET api/<PacienteController>/5
		[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PacienteController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PacienteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PacienteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
