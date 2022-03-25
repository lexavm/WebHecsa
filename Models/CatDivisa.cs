using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class CatDivisa
    {
        public CatDivisa()
        {
            TblCotizacionGenerals = new HashSet<TblCotizacionGeneral>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDivisa { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string DivisaDesc { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }

        public virtual ICollection<TblCotizacionGeneral> TblCotizacionGenerals { get; set; }
    }
}
