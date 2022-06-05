using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Tilisarao_Api.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Clave { get; set; }
        public string Especialidad { get; set; }
        public string Matricula { get; set; }

        public Medico(int id, string nombre, string apellido, string dni, string telefono, string email, string clave, string especialidad, string matricula)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Telefono = telefono;
            Email = email;
            Clave = clave;
            Especialidad = especialidad;
            Matricula = matricula;
        }
    }
}
