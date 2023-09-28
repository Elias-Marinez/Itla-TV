
using ItlaTV.Domain.Entities;
using ItlaTV.Infrastructure.Context;
using ItlaTV.Infrastructure.Core;
using ItlaTV.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ItlaTV.Infrastructure.Repositories
{
    public class SerieRepository : BaseRepository<Serie>, ISerieRepository
    {
        private readonly ApplicationContext _context;
        public SerieRepository(ApplicationContext context) : base(context)
        {
            this._context = context;
        }

        public override async Task<IEnumerable<Serie>> GetEntities()
        {
            return await _context.Series
                .Include(s => s.Genero)
                .Include(s => s.SGenero)
                .Include(s => s.Productora)
                .ToListAsync();
        }

        public async override Task<Serie> GetEntity(int id)
        {
            return await _context.Series
                .Include(s => s.Genero)
                .Include(s => s.SGenero)
                .Include(s => s.Productora)
                .FirstOrDefaultAsync(s => s.SerieId == id);
        }

    }
}
