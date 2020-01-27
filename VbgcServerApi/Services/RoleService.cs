using AutoMapper;
using System.Collections.Generic;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
	public class RoleService : IRoleService
	{
		private DataContext context;
		private readonly IMapper mapper;

		public RoleService(DataContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		public object Create(RoleDto dto)
		{
			var entity = mapper.Map<Role>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.RoleId; ;
		}

		public void Delete(int id)
		{
			var entity = context.Roles.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}

		public IEnumerable<RoleDto> GetAll()
		{
			return mapper.Map<IEnumerable<RoleDto>>(context.Roles);
		}

		public RoleDto GetById(int id)
		{
			var entity = context.Roles.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return mapper.Map<RoleDto>(entity);
		}

		public void Update(int id, RoleDto dto)
		{
			var entity = context.Roles.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			entity.RoleName = dto.RoleName;

			context.Update(entity);
			context.SaveChanges();
		}
	}
}
