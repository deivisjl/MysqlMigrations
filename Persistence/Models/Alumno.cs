using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Alumno")]
    public class Alumno
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string PrimerNombre { get; set; }
        
        [StringLength(50)]
        public string SegundoNombre { get; set; }
        
        [StringLength(50)]
        public string TercerNombre { get; set; }
        [Required]
        [StringLength(50)]
        public string PrimerApellido { get; set; }
        
        [StringLength(50)]
        public string SegundoApellido { get; set; }
        [Required]
        [StringLength(5)]
        public string Genero { get; set; }
        [Required]
        [StringLength(15)]
        public string Dpi { get; set; }
        
        [StringLength(20)]
        public string Telefono { get; set; }
        [Required]
        [StringLength(20)]
        public string Direccion { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }

        public ICollection<Inscrito> Inscrito { get; set; }
    }
}
