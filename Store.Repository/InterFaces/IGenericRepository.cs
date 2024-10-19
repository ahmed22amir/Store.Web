using Store.Data.Entity;
using Store.Repository.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Repository.InterFaces
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey? id);
        Task<IReadOnlyList<TEntity>> GetAllAsync();
        Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity> specs);
        Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specs);
        Task<int> GetCountWithSpecification(ISpecification<TEntity> specs);
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
