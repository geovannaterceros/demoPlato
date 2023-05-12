
namespace ProgramsManager.DAL.Interfaces
{
    public interface IDataAccess<TEntity> 
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(Guid id);

        Task<TEntity> CreateAsync(TEntity entity);

        Task<TEntity> UpdateAsync(Guid id,TEntity entity);

        Task<TEntity> DeleteAsync(Guid id);
    }
}
