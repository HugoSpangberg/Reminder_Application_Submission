
using Reminder_Shared.Context;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Reminder_Shared.Repositories;

public class BaseRepository<TEntity>(DataContext context) where TEntity : class
{
    private readonly DataContext _context = context;


    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return entity;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToList();
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<TEntity>();
        }
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);
            return entity!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public virtual TEntity Update(Expression<Func<TEntity, bool>> predicate, TEntity entity)
    {
        try
        {
            var updateEntity = _context.Set<TEntity>().FirstOrDefault(predicate);
            _context.Entry(updateEntity!).CurrentValues.SetValues(entity);
            _context.SaveChanges();
            return updateEntity!;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }

    public virtual bool Delete(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(predicate);
            _context.Remove(entity!);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }
}

