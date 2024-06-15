namespace Energy.Application.Interface
{
    public interface IAppGenericsBase<TEntity> where TEntity : class
    {
        void Add(TEntity t);
        void Update(TEntity t);
        void Delete(int id);
        TEntity GetById(int Id);
        IEnumerable<TEntity> GetAll();
    }
}
