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
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string TipoDireccionDesc { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }

        public virtual ICollection<TblClienteDireccion> TblClienteDirecciones { get; set; }
    }
}
