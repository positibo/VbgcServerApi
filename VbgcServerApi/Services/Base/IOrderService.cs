using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface IOrderService
    {
        OrderDto GetById(int id);
        IEnumerable<OrderDto> GetAll();
        object Create(OrderDto dto);
        void Update(int id, OrderDto dto);
        void Delete(int id);
    }
}
