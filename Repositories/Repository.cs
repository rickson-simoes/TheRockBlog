using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<TModel> where TModel : class, IEntity
    {
        public readonly SqlConnection _connection;
        public Repository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TModel> Get() => _connection.GetAll<TModel>();
        public TModel Get(int id) => _connection.Get<TModel>(id);
        public void Create(TModel entity)
        {
            entity.Id = 0;
            _connection.Insert<TModel>(entity);
        }

        public void Update(TModel entity)
        {
            if (entity.Id != 0)
            {
                _connection.Update<TModel>(entity);
            }
        }
        public void Delete(TModel entity)
        {
            if (entity.Id != 0)
            {
                _connection.Delete<TModel>(entity);
            }
        }
        public void Delete(int id)
        {
            if (id != 0)
                return;

            var entity = _connection.Get<TModel>(id);
            _connection.Delete<TModel>(entity);
        }
    }
}
