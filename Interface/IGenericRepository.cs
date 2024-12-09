using System.Linq.Expressions;
using EvaluationBackend.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace EvaluationBackend.Interface
{
<<<<<<< HEAD
    public interface IGenericRepository<T,TId>
    {
        Task<T?> GetById(TId id);
     
        Task<(List<TDto> data, int totalCount)> GetAll<TDto>(int pageNumber = 0, int pageSize = 10);
        Task<(List<TDto> data, int totalCount)> GetAll<TDto>(Expression<Func<T, bool>> predicate, int pageNumber = 0, int pageSize = 10);
      

        Task<(List<T> data, int totalCount)> GetAll(int pageNumber = 0,int pageSize = 10);

        Task<(List<T> data, int totalCount)> GetAll(Expression<Func<T, bool>> predicate,
        int pageNumber = 0,int pageSize = 10
=======
    public interface IGenericRepository<T, TId>
    {
        Task<T?> GetById(TId id);

        Task<(List<TDto> data, int totalCount)> GetAll<TDto>(int pageNumber = 0, int pageSize = 10);
        Task<(List<TDto> data, int totalCount)> GetAll<TDto>(Expression<Func<T, bool>> predicate, int pageNumber = 0, int pageSize = 10);

 
        Task<(List<T> data, int totalCount)> GetAll(int pageNumber = 0, int pageSize = 10);

        Task<(List<T> data, int totalCount)> GetAll(Expression<Func<T, bool>> predicate,
        int pageNumber = 0, int pageSize = 10
>>>>>>> 6c75216 (Initial commit)
        );

        Task<(List<T> data, int totalCount)> GetAll(
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
<<<<<<< HEAD
        int pageNumber = 0,int pageSize = 10
=======
        int pageNumber = 0, int pageSize = 10
>>>>>>> 6c75216 (Initial commit)
        );

        Task<(List<T> data, int totalCount)> GetAll(Expression<Func<T, bool>> predicate,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include,
<<<<<<< HEAD
        int pageNumber = 0,int pageSize = 10
        );
        
=======
        int pageNumber = 0, int pageSize = 10
        );

>>>>>>> 6c75216 (Initial commit)
        Task<T> Add(T entity);
        Task<T> Delete(TId id);
        Task<T> Update(T entity);
        Task<T> SoftDelete(TId id);
<<<<<<< HEAD
        
=======

>>>>>>> 6c75216 (Initial commit)
        Task<TDto?> Get<TDto>(Expression<Func<T, bool>> predicate);
        Task<T> Get(Expression<Func<T, bool>> predicate);
        Task<T> Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>> include);

    }
}