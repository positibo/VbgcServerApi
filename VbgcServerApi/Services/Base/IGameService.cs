using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface IGameService
    {
        GameDto GetById(int id);
        IEnumerable<GameDto> GetAll();
        object Create(GameDto dto);
        void Update(int id, GameDto dto);
        void Delete(int id);
    }
}
