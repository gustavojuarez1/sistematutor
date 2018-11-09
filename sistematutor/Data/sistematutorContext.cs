using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace sistematutor.Models
{
    public class sistematutorContext : DbContext
    {
        public sistematutorContext (DbContextOptions<sistematutorContext> options)
            : base(options)
        {
        }

        public DbSet<sistematutor.Models.retroalimentacion_preguntas> retroalimentacion_preguntas { get; set; }

        public DbSet<sistematutor.Models.resultados> resultados { get; set; }
    }
}
