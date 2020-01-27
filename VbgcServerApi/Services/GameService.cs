using AutoMapper;
using System.Collections.Generic;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
	public class GameService : IGameService
	{
		private DataContext context;
		private readonly IMapper mapper;

		public GameService(DataContext db, IMapper mapper)
		{
			this.context = db;
			this.mapper = mapper;
		}

		public IEnumerable<GameDto> GetAll()
		{
			return mapper.Map<IEnumerable<GameDto>>(context.Games);
		}

		public GameDto GetById(int id)
		{
			var entity = context.Games.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return mapper.Map<GameDto>(entity);
		}

		public object Create(GameDto dto)
		{
			var entity = mapper.Map<Game>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.GameId;
		}

		public void Update(int id, GameDto dto)
		{
			var entity = context.Games.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.Games.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}
