using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P2_AP1_Julio_Cesar.BLL;
using P2_AP1_Julio_Cesar.Entidades;

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

        public ProyectosDetalle()
        {
            Id = 0;
            ProyectoId = 0;
            TipoTareaId = 0;
            Requerimiento = string.Empty;
            Tiempo = 0;
            TiposTareas = null;
            Proyecto = null;
        }
        public ProyectosDetalle(int proy, int tipo, string req, int tiempo, TiposTareas tarea, Proyectos proyect)
        {
            Id = 0;
            ProyectoId = proy;
            TipoTareaId = tipo;
            Requerimiento = req;
            Tiempo = tiempo;
            TiposTareas = tarea;
            Proyectos = proyect;
        }
    }
}
