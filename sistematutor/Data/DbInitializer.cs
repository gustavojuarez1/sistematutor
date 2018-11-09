using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sistematutor.Models;

namespace sistematutor.Data
{
    public class DbInitializer
    {
        public static void Initialize(sistematutorContext context)
        {
            context.Database.EnsureCreated();
            if (context.resultados.Any())
            {
                return;
            }
            var resultados = new resultados[]
            {
                //
            };
            foreach (resultados a in resultados)
            {
                context.resultados.Add(a);
            }
            context.SaveChanges();
        }
    }

}
