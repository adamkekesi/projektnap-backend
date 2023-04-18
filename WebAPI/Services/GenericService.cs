using Microsoft.EntityFrameworkCore;

namespace WebAPI.Services
{
    public class GenericService<T> where T : class
    {
        private readonly DataContext _dataContext;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public GenericService(DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = dataContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public virtual T Create(T entity)
        {
            _dataContext.Set<T>().Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }
        public virtual T? Read(int key)
        {
            return _dataContext.Set<T>().Find(key);
        }

        public virtual IEnumerable<T> ReadAll()
        {
            return _dataContext.Set<T>().ToList();
        }

        public virtual T Update(T entity)
        {
            _dataContext.Entry(entity).State = EntityState.Modified;
            _dataContext.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            _dataContext.Set<T>().Remove(entity);
            _dataContext.SaveChanges();
        }
    }
}
