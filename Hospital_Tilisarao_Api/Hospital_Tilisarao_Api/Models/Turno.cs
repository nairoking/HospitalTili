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
        public DateTime HoraInicio{ get; set; }
        public DateTime Dia { get; set; }
        [ForeignKey(nameof(MedicoId))]
        public int MedicoId { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public int PacienteId { get; set; }

        public Turno(int id, DateTime horaInicio, DateTime dia, int medico_Id, int paciente_Id)
        {
            Id = id;
            HoraInicio = horaInicio;
            Dia = dia;
            MedicoId = medico_Id;
            PacienteId = paciente_Id;
        }
    }
}
