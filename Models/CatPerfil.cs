using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class CatPerfil
    {
        public CatPerfil()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPerfil { get; set; }
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Campo Requerido")]
        public string PerfilDesc { get; set; }
        [Column("FechaRegistro")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Registro")]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Estatus")]
        public int IdEstatusRegistro { get; set; }

        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
