using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace WebHecsa.Models
{
    public partial class CatCodigosPostale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdCodigosPostales")]
        [Display(Name = "ID IdCodigosPostales")]
        public int IdCodigosPostales { get; set; }
        public string Dcodigo { get; set; }
        public string Dasenta { get; set; }
        public string DtipoAsenta { get; set; }
        public string Dmnpio { get; set; }
        public string Destado { get; set; }
        public string Dciudad { get; set; }
        public string Dcp { get; set; }
        public string Cestado { get; set; }
        public string Coficina { get; set; }
        public string Ccp { get; set; }
        public string CtipoAsenta { get; set; }
        public string Cmnpio { get; set; }
        public string IdAsentaCpcons { get; set; }
        public string Dzona { get; set; }
        public string CcveCiudad { get; set; }
    }
}
