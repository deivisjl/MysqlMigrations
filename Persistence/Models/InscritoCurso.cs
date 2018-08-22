using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("InscritoCurso")]
    public class InscritoCurso
    {
        public int Id { get; set; }

        public Inscrito Inscrito { get; set; }
        public int InscritoId { get; set; }

        public PensumCurso PensumCurso { get; set; }
        public int PensumCursoId { get; set; }

        public CicloEscolar CicloEscolar { get; set; }
        public int CicloEscolarId { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
    }
}
