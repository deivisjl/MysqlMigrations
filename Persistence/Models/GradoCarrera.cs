using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("GradoCarrera")]
    public class GradoCarrera
    {
        public int Id { get; set; }

        public Grado Grado { get; set; }
        public int GradoId { get; set; }

        public Carrera Carrera { get; set; }
        public int CarreraId { get; set; }

        public ICollection<Salon> Salon { get; set; }
    }
}
