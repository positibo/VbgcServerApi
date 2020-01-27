using System.Collections.Generic;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public interface IPlayerSizeService
    {
        PlayerSizeDto GetById(int id);
        IEnumerable<PlayerSizeDto> GetAll();
        object Create(PlayerSizeDto dto);
        void Update(int id, PlayerSizeDto dto);
        void Delete(int id);
    }
}
