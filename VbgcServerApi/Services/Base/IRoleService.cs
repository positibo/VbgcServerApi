using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleDto> GetAll();
        RoleDto GetById(int id);
        object Create(RoleDto dto);
        void Update(int id, RoleDto dto);
        void Delete(int id);
    }
}
