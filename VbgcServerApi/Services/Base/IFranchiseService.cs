using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface IFranchiseService
    {
        FranchiseDto GetById(int id);
        IEnumerable<FranchiseDto> GetAll();
        object Create(FranchiseDto dto);
        void Update(int id, FranchiseDto dto);
        void Delete(int id);
    }
}
