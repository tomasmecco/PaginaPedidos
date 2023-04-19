using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PaginaPedidos.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(200)]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar"), MaxLength(500)]
        public string Descripcion { get; set; }

        public ICollection<Product> Productos { get; set; }
	}
}