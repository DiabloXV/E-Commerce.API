using Domain.Entities;

namespace Domain.Contracts
{
    public interface IGenericRepository <TEntity, Tkey> where TEntity : BaseEntity <Tkey>
    {
        Task <TEntity?> GetAsync(Tkey Id);

        Task<IEnumerable<TEntity>> GetAllAsync(bool trackChanges);

        Task AddAsync(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);
    }
}
