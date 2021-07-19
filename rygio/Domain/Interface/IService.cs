using rygio.Helper.pagination;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace rygio.Domain.Interface
{
    public interface IService<T> where T : class, new()
    {
        Task<IEnumerable<T>> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        PageList<T> GetAll(PageParameter pagination);
        PageList<T> GetAll(Expression<Func<T, bool>> predicate, PageParameter pagination);
        Task<int> Count();
        Task<int> CountWhere(Expression<Func<T, bool>> predicate);
        Task<T> GetSingle(Expression<Func<T, bool>> predicate);
        T GetLastAsync(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> FindAllInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<T> FindSingleInclude(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> Add(T entity);
        void Add(List<T> entity);
        void Update(T entity);
        T FindFirst(Expression<Func<T, bool>> predicate);
        void UndoAdd(T entity);
        void UndoAdd(List<T> entity);
        void Delete(T entity);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
        Task CommitAsync();
    }
}
