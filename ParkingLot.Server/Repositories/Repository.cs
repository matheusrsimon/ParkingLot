using Microsoft.EntityFrameworkCore;
using ParkingLot.Server.Data;
using ParkingLot.Server.Models;

namespace ParkingLot.Server.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity, new()
    {
        protected readonly ApplicationDbContext context;

        protected abstract DbSet<TEntity> Set { get; }

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public abstract TEntity? UpdateValues(TEntity input, TEntity? entity);

        public TEntity? Find(int id)
        {
            return Set.Find(id);
        }

        public IEnumerable<TEntity> Filter(Func<TEntity, bool>? predicate = null)
        {
            return predicate == null ? Set : Set.Where(predicate);
        }

        public int? Create(TEntity input)
        {
            Set.Add(input);
            context.SaveChanges();
            return input.Id;
        }

        public bool Update(TEntity input)
        {
            TEntity? entity = Set.Find(input.Id);
            UpdateValues(input, entity);
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Set.Remove(new TEntity { Id = id });
            return context.SaveChanges() > 0;
        }
    }
}
