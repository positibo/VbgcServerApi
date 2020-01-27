using AutoMapper;
using System.Collections.Generic;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;
using VbgcServerApi.Services;

namespace VbgcServerApi.Services
{
	public class ComplexityService : IComplexityService
	{
		private DataContext context;
		private readonly IMapper mapper;

		public ComplexityService(DataContext db, IMapper mapper)
		{
			this.context = db;
			this.mapper = mapper;
		}

		public IEnumerable<ComplexityDto> GetAll()
		{
			return mapper.Map<IEnumerable<ComplexityDto>>(context.Complexities);
		}

		public ComplexityDto GetById(int id)
		{
			var entity = context.Complexities.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return mapper.Map<ComplexityDto>(entity);
		}

		public object Create(ComplexityDto dto)
		{
			var entity = mapper.Map<Complexity>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.ComplexityId;
		}

		public void Update(int id, ComplexityDto dto)
		{
			var entity = context.Complexities.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.Complexities.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}
