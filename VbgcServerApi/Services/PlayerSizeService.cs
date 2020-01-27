using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
	public class PlayerSizeService : IPlayerSizeService
	{
		private DataContext context;
		private readonly IMapper mapper;

		public PlayerSizeService(DataContext db, IMapper mapper)
		{
			this.context = db;
			this.mapper = mapper;
		}

		public IEnumerable<PlayerSizeDto> GetAll()
		{
			return mapper.Map<IEnumerable<PlayerSizeDto>>(context.PlayerSizes);
		}

		public PlayerSizeDto GetById(int id)
		{
			var entity = context.PlayerSizes.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return mapper.Map<PlayerSizeDto>(entity);
		}

		public object Create(PlayerSizeDto dto)
		{
			var entity = mapper.Map<PlayerSize>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.PlayerSizeId;
		}

		public void Update(int id, PlayerSizeDto dto)
		{
			var entity = context.PlayerSizes.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.PlayerSizes.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}
