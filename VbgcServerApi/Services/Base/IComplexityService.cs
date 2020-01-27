using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface IComplexityService
    {
        ComplexityDto GetById(int id);
        IEnumerable<ComplexityDto> GetAll();
        object Create(ComplexityDto dto);
        void Update(int id, ComplexityDto dto);
        void Delete(int id);
    }
}
