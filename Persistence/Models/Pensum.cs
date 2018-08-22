using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Pensum")]
    public class Pensum
    {
        public int Id { get; set; }

        [Required]
        public int Activo { get; set; }

        public GradoCarrera GradoCarrera { get; set; }
        public int GradoCarreraId { get; set; }

        public CicloEscolar CicloEscolar { get; set; }
        public int CicloEscolarId { get; set; }

        public ICollection<PensumCurso> PensumCurso { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
    }
}
