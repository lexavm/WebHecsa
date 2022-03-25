using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class CatTipoEnvio
    {
        public CatTipoEnvio()
        {
            TblCotizacionGenerals = new HashSet<TblCotizacionGeneral>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTiposEnvio { get; set; }
        public string TiposEnvioDesc { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstatusRegistro { get; set; }

        public virtual ICollection<TblCotizacionGeneral> TblCotizacionGenerals { get; set; }
    }
}
