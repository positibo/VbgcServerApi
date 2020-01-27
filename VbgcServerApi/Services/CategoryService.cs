using AutoMapper;
using System.Collections.Generic;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;
using VbgcServerApi.Services;

namespace VbgcServerApi.Services
{
	public class CategoryService : ICategoryService
	{
		private DataContext context;
		private readonly IMapper mapper;

		public CategoryService(DataContext db, IMapper mapper)
		{
			this.context = db;
			this.mapper = mapper;
		}

		public IEnumerable<CategoryDto> GetAll()
		{
			return mapper.Map<IEnumerable<CategoryDto>>(context.Categories);
		}

		public CategoryDto GetById(int id)
		{
			var entity = context.Categories.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return mapper.Map<CategoryDto>(entity);
		}

		public object Create(CategoryDto dto)
		{
			var entity = mapper.Map<Category>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.CategoryId;
		}

		public void Update(int id, CategoryDto dto)
		{
			var entity = context.Categories.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.Categories.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}
