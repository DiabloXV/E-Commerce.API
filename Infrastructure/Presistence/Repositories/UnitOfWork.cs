
using System.ComponentModel.DataAnnotations;

namespace Persistence.Repositories
{
    public class UnitOfWork : IIUnitOfWork
    {
        private readonly StoreContext _storeContext;
        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
            _repositories = new();
        }

        public IGenericRepository<TEntity, Tkey> GetRepository<TEntity, Tkey>() where TEntity : BaseEntity<Tkey>
            => (IGenericRepository<TEntity, Tkey>)_repositories.GetOrAdd(typeof(TEntity).Name, _ => new GenericRepository<TEntity, Tkey>(_storeContext));

        //var typeName = typeof(TEntity).Name;

        //if(_repositories.ContainsKey(typeName)) return (IGenericRepository <TEntity,Tkey>) _repositories[typeName];

        //var repo =  new GenericRepository<TEntity, Tkey>(_storeContext);

        //_repositories.Add(typeName, repo);

        //return repo;

        //Return me



        public async Task<int> SaveChangesAsync() => await _storeContext.SaveChangesAsync();

        //sfsfsfsfs
    }
}
