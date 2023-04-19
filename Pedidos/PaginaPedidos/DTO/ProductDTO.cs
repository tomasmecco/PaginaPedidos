using PaginaPedidos.Models;

namespace PaginaPedidos
{
	public class ProductDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal SellPrice { get; set; }
		public int CategoriaId { get; set; }
		public List<Categoria> Categorias { get; set; }
	}
}
