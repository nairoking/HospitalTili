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

        [ForeignKey(nameof(Historial_Id))]
        public int Historial_Id { get; set; }

        [ForeignKey(nameof(Turno_Id))]
        public int Turno_Id { get; set; }

        public string Descripcion { get; set; }

        public ItemHistorial(int id, int historial_Id, int turno_Id, string descripcion)
        {
            Id = id;
            Historial_Id = historial_Id;
            Turno_Id = turno_Id;
            Descripcion = descripcion;
        }
    }
}
