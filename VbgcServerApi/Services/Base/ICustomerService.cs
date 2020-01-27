using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface ICustomerService
    {
        CustomerDto GetById(int id);
        IEnumerable<CustomerDto> GetAll();
        object Create(CustomerDto dto);
        void Update(int id, CustomerDto dto);
        void Delete(int id);
    }
}
