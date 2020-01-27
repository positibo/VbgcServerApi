using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface ITransactionStatusService
    {
        TransactionStatusDto GetById(int id);
        IEnumerable<TransactionStatusDto> GetAll();
        object Create(TransactionStatusDto dto);
        void Update(int id, TransactionStatusDto dto);
        void Delete(int id);
    }
}
