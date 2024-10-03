using Domain.Entities;
using System.Formats.Tar;

namespace Domain.Contracts
{
    public interface IIUnitOfWork
    {
        public Task<int> SaveChangesAsync();

        IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>;
    }
}
