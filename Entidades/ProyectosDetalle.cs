using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Julio_Cesar.Entidades
{
   public class ProyectosDetalle
    {
        [Key]

        public int Id { get; set; }
        public int TipoTareaId { get; set; }
        public int ProyectoId { get; set; }
        public string Requerimiento { get; set; }
        public int Tiempo { get; set; }

        [ForeignKey("TipoTareaId")]
        public TiposTareas TiposTareas { get; set; }
        public Proyectos proyecto { get; set; }

        public ProyectosDetalle(int v)
        {
            Id = 0;
            ProyectoId = 0;
            TipoTareaId = 0;
            Tiempo = 0;
            Requerimiento = string.Empty;
            TiposTareas = null;
            proyecto = null;
        }

    }
}
