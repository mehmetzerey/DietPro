namespace Identity.Application.Repository;

public interface IRepository<T> where T : class
{
    DbSet<T> Table { get; }
}
