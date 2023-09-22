
using ItlaTV.Domain.Entities;
using ItlaTV.Infrastructure.Context;
using ItlaTV.Infrastructure.Core;
using ItlaTV.Infrastructure.Interfaces;

namespace ItlaTV.Infrastructure.Repositories
{
    public class ProductoraRepository : BaseRepository<Productora>, IProductoraRepository
    {
        private readonly ApplicationContext _context;
        public ProductoraRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }
    }
}
