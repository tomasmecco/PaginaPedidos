using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PaginaPedidos.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar"), MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int SellPrice { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }
               
        public int Cantidad { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
