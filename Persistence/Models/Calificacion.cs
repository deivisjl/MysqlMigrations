using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Calificacion")]
    public class Calificacion
    {
        public int Id { get; set; }
        [Required]
        public int Valor { get; set; }

        public InscritoCurso InscritoCurso { get; set; }
        public int InscritoCursoId { get; set; }

        public Bimestre Bimestre { get; set; }
        public int BimestreId { get; set; }

        public CicloEscolar CicloEscolar { get; set; }
        public int CicloEscolarId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
    }
}
