
using Reminder_Shared.Context;
using System;
using System.Linq.Expressions;

namespace Reminder_Shared.Repositories;

public class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;


    public TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }
    public IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
        
    }
    public TEntity Get(Expression<Func<TEntity, bool>> predicate) 
    {
       var entity =  _context.Set<TEntity>().FirstOrDefault(predicate);
        return entity!;
    }
    public TEntity Update(Expression<Func<TEntity, bool>> predicate, TEntity entity)
    {
        var updateEntity = _context.Set<TEntity>().FirstOrDefault(predicate);
        _context.Entry(updateEntity!).CurrentValues.SetValues(entity);
        _context.SaveChanges();
        return updateEntity!;
    }

    public bool Delete(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(predicate);
        _context.Remove(entity!);
        _context.SaveChanges();
        return true;
    }
}
