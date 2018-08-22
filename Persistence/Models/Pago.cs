using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Pago")]
    public class Pago
    {
        public int Id { get; set; }

        public Inscrito Inscrito { get; set; }
        public int InscritoId { get; set; }

        public Mes Mes { get; set; }
        public int MesId { get; set; }

        public CicloEscolar CicloEscolar { get; set; }
        public int CicloEscolarId { get; set; }

        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

        [Required]
        public int Monto { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
    }
}
