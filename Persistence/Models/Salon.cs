using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Salon")]
    public class Salon
    {
        public int Id { get; set; }

        public Seccion Seccion { get; set; }
        public int SeccionId { get; set; }

        public GradoCarrera GradoCarrera { get; set; }
        public int GradoCarreraId { get; set; }

        public ICollection<Inscrito> Inscrito { get; set; }
        public ICollection<CursoProfesor> CursoProfesor { get; set; }
    }
}
