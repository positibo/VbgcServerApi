using AutoMapper;
using System.Linq;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Role, RoleDto>();
			CreateMap<User, UserDto>()
				.ForMember(dest => dest.Id, src => src.MapFrom(o => o.UserId))
				.ForMember(dest => dest.Roles, src => src.MapFrom(o => o.UserInRoles.Select(s => s.Role)));

			CreateMap<RoleDto, Role>();
			CreateMap<UserDto, User>()
				.ForMember(dest => dest.UserId, src => src.MapFrom(o => o.Id));
			CreateMap<RegisterDto, User>();

			CreateMap<CategoryDto, Category>();
			CreateMap<ComplexityDto, Complexity>();
			CreateMap<CustomerDto, Customer>();
			CreateMap<TransactionStatusDto, TransactionStatus>();
			CreateMap<GameDto, Game>();
			CreateMap<OrderDto, Order>();
			CreateMap<OrderDetailDto, OrderDetail>();
			CreateMap<PlayerSizeDto, PlayerSize>();
			CreateMap<Category, CategoryDto>();
			CreateMap<Complexity, ComplexityDto>();
			CreateMap<Customer, CustomerDto>();
			CreateMap<TransactionStatus, TransactionStatusDto>();
			CreateMap<Game, GameDto>();
			CreateMap<Order, OrderDto>();
			CreateMap<PlayerSize, PlayerSizeDto>();
			CreateMap<Franchise, FranchiseDto>();
			CreateMap<FranchiseDto, Franchise>();

			CreateMap<OrderDetail, OrderDetailDto>()
				.ForMember(dest => dest.GameName, opt => opt.MapFrom(src => src.Game.GameName));
		}
	}
}
