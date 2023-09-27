
using ItlaTV.Domain.Entities;
using ItlaTV.Infrastructure.Context;
using ItlaTV.Infrastructure.Core;
using ItlaTV.Infrastructure.Interfaces;

namespace ItlaTV.Infrastructure.Repositories
{
    public class SerieRepository : BaseRepository<Serie>, ISerieRepository
    {
        private readonly ApplicationContext _context;
        public SerieRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }
    }
}
