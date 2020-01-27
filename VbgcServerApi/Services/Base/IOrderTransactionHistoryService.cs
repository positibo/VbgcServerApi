using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface IOrderTransactionHistoryService
    {
        OrderTransactionHistoryDto GetById(int id);
        IEnumerable<OrderTransactionHistoryDto> GetAll();
        object Create(OrderTransactionHistoryDto dto);
    }
}
