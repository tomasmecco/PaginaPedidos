
using PaginaPedidos.Models;
using AutoMapper;

namespace PaginaPedidos
{
	public class ProductProfile : Profile
	{
		public ProductProfile()
		{
			CreateMap<ProductDTO, Product>().ReverseMap();
		}

	}
}
