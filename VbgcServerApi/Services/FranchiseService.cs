using AutoMapper;
using System;
using System.Collections.Generic;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public class FranchiseService : IFranchiseService
    {
        private DataContext context;
        private readonly IMapper mapper;

        public FranchiseService(DataContext db, IMapper mapper)
        {
            this.context = db;
            this.mapper = mapper;
        }

        public object Create(FranchiseDto dto)
        {
            dto.CreatedDate = DateTime.UtcNow;
            var entity = mapper.Map<Franchise>(dto);
            context.Add(entity);
            context.SaveChanges();
            return entity.FranchiseId;
        }

        public void Delete(int id)
        {
            var entity = context.Franchises.Find(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            context.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<FranchiseDto> GetAll()
        {
            return mapper.Map<IEnumerable<FranchiseDto>>(context.Franchises);
        }

        public FranchiseDto GetById(int id)
        {
            var entity = context.Franchises.Find(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }
            return mapper.Map<FranchiseDto>(entity);
        }

        public void Update(int id, FranchiseDto dto)
        {
            var entity = context.Franchises.Find(id);
            if (entity == null)
            {
                throw new NotFoundException();
            }

            context.Update(mapper.Map(dto, entity));
            context.SaveChanges();
        }
    }
}
