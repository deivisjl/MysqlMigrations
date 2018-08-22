using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Inscrito")]
    public class Inscrito
    {
        public int id { get; set; }
        [Required]
        public int Repitente { get; set; }

        [Required]
        public int Estado { get; set; }

        public Alumno Alumno { get; set; }
        public int AlumnoId { get; set; }

        public Salon Salon { get; set; }
        public int SalonId { get; set; }

        public CicloEscolar CicloEscolar { get; set; }
        public int CicloEscolarId { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }

        public ICollection<InscritoCurso> InscritoCurso { get; set; }

        
    }
}
