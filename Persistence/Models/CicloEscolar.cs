using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("CicloEscolar")]
    public class CicloEscolar
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        public int Activo { get; set; }

        public ICollection<Inscrito> Inscrito { get; set; }
        public ICollection<Pensum> Pensum { get; set; }
        public ICollection<InscritoCurso> InscritoCurso { get; set; }
        public ICollection<CursoProfesor> CursoProfesor { get; set; }
    }
}
