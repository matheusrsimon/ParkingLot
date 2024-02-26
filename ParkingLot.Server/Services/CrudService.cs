using ParkingLot.Server.Dtos;
using ParkingLot.Server.Models;

namespace ParkingLot.Server.Repositories
{
    public abstract class CrudService<TEntity, TDto, TRepository> : ICrudService<TEntity, TDto>
        where TEntity : Entity, new()
        where TDto : EntityDto<TEntity>, new()
        where TRepository: IRepository<TEntity>
    {
        protected readonly TRepository repository;

        public CrudService(TRepository repository)
        {
            this.repository = repository;
        }

        public TDto? Find(int id)
        {
            TEntity? entity = repository.Find(id);
            if (entity == null)
            {
                return null;
            }
            TDto result = new TDto();
            result.FromEntity(entity);
            return result;
        }

        public IEnumerable<TDto> Filter(Func<TEntity, bool> predicate)
        {
            return repository.Filter(predicate).Select(entity =>
            {
                TDto result = new TDto();
                result.FromEntity(entity);
                return result;
            });
        }

        public int? Create(TDto dto)
        {
            TEntity entity = dto.ToEntity();
            return repository.Create(entity);
        }

        public bool Update(TDto dto)
        {
            TEntity entity = dto.ToEntity();
            return repository.Update(entity);
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
