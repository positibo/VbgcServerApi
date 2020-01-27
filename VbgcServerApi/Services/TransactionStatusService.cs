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
	public class TransactionStatusService : ITransactionStatusService
	{
		private DataContext context;
		private readonly IMapper mapper;

		public TransactionStatusService(DataContext db, IMapper mapper)
		{
			this.context = db;
			this.mapper = mapper;
		}

		public IEnumerable<TransactionStatusDto> GetAll()
		{
			return mapper.Map<IEnumerable<TransactionStatusDto>>(context.TransactionStatus);
		}

		public TransactionStatusDto GetById(int id)
		{
			var entity = context.TransactionStatus.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			return mapper.Map<TransactionStatusDto>(entity);
		}

		public object Create(TransactionStatusDto dto)
		{
			var entity = mapper.Map<TransactionStatus>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.TransactionStatusId;
		}

		public void Update(int id, TransactionStatusDto dto)
		{
			var entity = context.TransactionStatus.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.TransactionStatus.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}
