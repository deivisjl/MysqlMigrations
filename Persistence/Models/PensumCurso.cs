using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("PensumCurso")]
    public class PensumCurso
    {
        public int Id { get; set; }

        public Pensum Pensum { get; set; }
        public int PensumId { get; set; }

        public Curso Curso { get; set; }
        public int CursoId { get; set; }

        public ICollection<InscritoCurso> InscritoCurso { get; set; }
        public ICollection<CursoProfesor> CursoProfesor { get; set; }
    }
}
