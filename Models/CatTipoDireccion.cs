using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class CatTipoDireccion
    {
        public CatTipoDireccion()
        {
            TblClienteDirecciones = new HashSet<TblClienteDireccion>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoDireccion { get; set; }
        public string TipoDireccionDesc { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual ICollection<TblClienteDireccion> TblClienteDirecciones { get; set; }
    }
}
