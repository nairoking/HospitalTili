using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Tilisarao_Api.Models
{
    public class Historial
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(PacienteId))]
        public int PacienteId { get; set; }

        public Historial(int id, int pacienteId)
        {
            Id = id;
            PacienteId = pacienteId;
        }
    }
}
