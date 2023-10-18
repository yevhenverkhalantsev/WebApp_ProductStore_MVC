using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using oblig1_Yevhen_Verkhalantsev.EntityFramework.Repository;

namespace oblig1_Yevhen_Verkhalantsev.Tests.Fakes.FakeRepository;

public class FakeRepository<T>: IGenericRepository<T> where T:class
{
    private readonly ICollection<T> _db;

    public FakeRepository()
    {
        _db = new Collection<T>();
    }
    
    public async Task Create(T entity)
    {
        _db.Add(entity);
    }

    public async Task Update(T entity)
    {
        T record = _db.FirstOrDefault(entity);
        record = entity;
    }

    public async Task Delete(T entity)
    {
        _db.Remove(entity);
    }

    public async Task<T> GetById(long id)
    {
        return _db.FirstOrDefault();
    }

    public IQueryable<T> GetAll()
    {
        return _db.AsQueryable();
    }
    
    private long GetIdFromEntity(T entity)
    {
        var property = entity.GetType().GetProperty("Id");
        if (property != null)
        {
            return (long)property.GetValue(entity, null);
        }
        return 0;
    }
}