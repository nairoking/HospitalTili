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
        [ForeignKey(nameof(Paciente_Id))]
        public int Paciente_Id { get; set; }

        public Historial(int id, int paciente_Id)
        {
            Id = id;
            Paciente_Id = paciente_Id;
        }
    }
}
