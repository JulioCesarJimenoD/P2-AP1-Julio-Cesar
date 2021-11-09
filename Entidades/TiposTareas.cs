using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2_AP1_Julio_Cesar.Entidades
{
   public class TiposTareas
    {
        [Key]
        public int TipoTareaId { get; set; }
        public int Acomulado { get; set; }
        public string DecripcionTipoTarea { get; set; }
    }
}
