using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Tilisarao_Api.Models
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }
        public String HoraInicio{ get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey(nameof(MedicoId))]
        public int MedicoId { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public int PacienteId { get; set; }

       public Medico medico { get; set; }
        public Paciente paciente { get; set; }


        
    }
}
