using Achilles.Acme.Content.Data.Models;
using Achilles.Acme.Content.Models;
using Achilles.Acme.Data.Services;
using Achilles.Acme.Plugins;
using System.Linq;
using System.Threading.Tasks;

namespace Achilles.Acme.Content.Services
{
    public abstract class ContentServiceBase<TEntity> : ServiceBase<TEntity>
        where TEntity : ContentItem
    {
        #region Fields

        private IContentRepository<TEntity> _repository;

        #endregion

        #region Constructor(s)

        public ContentServiceBase( IPlugin plugin, IContentRepository<TEntity> repository ) : base( repository )
        {
            _repository = repository;
        }

        #endregion

        #region Validation

        //public abstract ServiceResult Validate( TEntity model );

        #endregion

        #region Query Methods

        public virtual IQueryable<TEntity> GetByStatus( Status status = Status.Published )
        {
            return _repository.GetByStatus( status );
        }

        public virtual async Task<TEntity> GetAsync( int id, Status status = Status.Published )
        {
            return await _repository.GetAsync( id, status );
        }

        #endregion
    }
}
