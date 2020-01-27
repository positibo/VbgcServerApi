using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface ICategoryService
    {
        CategoryDto GetById(int id);
        IEnumerable<CategoryDto> GetAll();
        object Create(CategoryDto dto);
        void Update(int id, CategoryDto dto);
        void Delete(int id);
    }
}
