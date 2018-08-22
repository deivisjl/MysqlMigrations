using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombres { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(20)]
        public string Dpi { get; set; }

        public int Telefono { get; set; }
        [Required]
        [StringLength(100)]
        public string Direccion { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(150)]
        public string Password { get; set; }

        [Required]
        public int Estado { get; set; }

        public Rol Rol { get; set; }
        public int RolId { get; set; }

        public ICollection<CursoProfesor> CursoProfesor { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Fecha { get; set; }
    }
}
