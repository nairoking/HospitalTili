using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Tilisarao_Api.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<ItemHistorial> ItemHistorial { get; set; }
        public DbSet<Historial> Historial { get; set; }


    }
}
