using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class TipoEdicion
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Edición")]
        public string Descripcion { get; set; }
    }
}
