namespace Library.Application.UnitOfWork;

public interface IUnitOfWork
{
    Task SaveChanges();
}