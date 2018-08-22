using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Carrera")]
    public class Carrera
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public Nivel Nivel { get; set; }
        public int NivelId { get; set; }

        public ICollection<GradoCarrera> GradoCarrera { get; set; }
    }
}
