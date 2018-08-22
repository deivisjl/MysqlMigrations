using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Curso")]
    public class Curso
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }

        public ICollection<PensumCurso> PensumCurso { get; set; }
    }
}
