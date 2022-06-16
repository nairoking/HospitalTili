using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Tilisarao_Api.Models
{
    public class ItemHistorial
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(HistorialId))]
        public int HistorialId { get; set; }
        [ForeignKey(nameof(MedicoId))]
        public int MedicoId { get; set; }
        public DateTime Fecha { get; set; }
        public string Archivo { get; set; }
        public string Descripcion { get; set; }
        public Medico Medico { get; set; }

        
    }
}
