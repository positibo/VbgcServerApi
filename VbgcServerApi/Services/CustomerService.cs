using AutoMapper;
using System.Collections.Generic;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
	public class CustomerService : ICustomerService
	{
		private DataContext context;
		private readonly IMapper mapper;

		public CustomerService(DataContext db, IMapper mapper)
		{
			this.context = db;
			this.mapper = mapper;
		}

		public IEnumerable<CustomerDto> GetAll()
		{
			return mapper.Map<IEnumerable<CustomerDto>>(context.Customers);
		}

		public CustomerDto GetById(int id)
		{
			var entity = context.Customers.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return mapper.Map<CustomerDto>(entity);
		}

		public object Create(CustomerDto dto)
		{
			var entity = mapper.Map<Customer>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.CustomerId;
		}

		public void Update(int id, CustomerDto dto)
		{
			var entity = context.Customers.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.Customers.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}
