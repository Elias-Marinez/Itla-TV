
using ItlaTV.Domain.Entities;
using ItlaTV.Infrastructure.Context;
using ItlaTV.Infrastructure.Core;
using ItlaTV.Infrastructure.Interfaces;

namespace ItlaTV.Infrastructure.Repositories
{
    public class GeneroRepository : BaseRepository<Genero>, IGeneroRepository
    {
        private readonly ApplicationContext _context;
        public GeneroRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }
    }
}
