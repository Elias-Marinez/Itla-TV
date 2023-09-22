
using ItlaTV.Domain.Entities;
using ItlaTV.Domain.Repository;
using ItlaTV.Infrastructure.Context;
using ItlaTV.Infrastructure.Core;

namespace ItlaTV.Infrastructure.Repositories
{
    public class SerieRepository : BaseRepository<Serie>, IBaseRepository<Serie>
    {
        private readonly ApplicationContext _context;
        public SerieRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }
    }
}
