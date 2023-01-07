namespace Identity.Application.Repository;

public interface IWriteRepository<T> : IRepository<T> where T : class
{
    Task<int> SaveAsync();
}
