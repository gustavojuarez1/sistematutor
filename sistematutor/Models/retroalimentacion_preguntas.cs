using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sistematutor.Models
{
    public class retroalimentacion_preguntas
    {
        [Key]
        public int id_retroalimentacion { get; set; }
        public int id_ejercicio { get; set; }
        public int id_temas { get; set; }


    }
}
