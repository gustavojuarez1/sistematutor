using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sistematutor.Models

{
    public class resultados
    {
        [Key]
        public int id_resultados { get; set; } 

        public int id_respuestas_correctas { get; set; }
        public int id_respuestas_incorrectas { get; set; }
        public int id_ejercicio { get; set; }
        public int id_usuario { get; set; }
    }
}
