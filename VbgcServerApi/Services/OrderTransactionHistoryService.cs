using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;
using VbgcServerApi.Services;

namespace VbgcServerApi.Services
{
    public class OrderTransactionHistoryService : IOrderTransactionHistoryService
    {
        private DataContext context;
        private readonly IMapper mapper;

        public OrderTransactionHistoryService(DataContext db, IMapper mapper)
        {
            this.context = db;
            this.mapper = mapper;
        }

        public object Create(OrderTransactionHistoryDto dto)
        {
            var entity = mapper.Map<OrderTransactionHistory>(dto);
            context.Add(entity);
            context.SaveChanges();
            return entity.OrderId;
        }

        public IEnumerable<OrderTransactionHistoryDto> GetAll()
        {
            return mapper.Map<IEnumerable<OrderTransactionHistoryDto>>(context.OrderTransactionHistories);
        }

        public OrderTransactionHistoryDto GetById(int id)
        {
            var entity = context.OrderTransactionHistories.Find(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            return mapper.Map<OrderTransactionHistoryDto>(entity);
        }
    }
}
