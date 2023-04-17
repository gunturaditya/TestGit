using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.EntityFrameworkCore;

namespace LatDBfirstAPI.Repotitory
{
    public class GeneralRepository<Tentity, Key, TContext> : IGeneralContract<Tentity, Key>
        where Tentity : class
        where TContext : MyContext
    {
        protected  TContext _context;
        public GeneralRepository(TContext context)
        {
            _context = context;
        }
        public async Task deleteAsync(Key key)
        {
            var identity = await GetbyIDAsync(key);
            _context.Set<Tentity>().Remove(identity);
            await _context.SaveChangesAsync();

        }

        public async Task< IEnumerable<Tentity>> GetallAsync()
        {
            return await _context.Set<Tentity>().ToListAsync();
        }

        public async Task<Tentity>? GetbyIDAsync(Key key)
        {
            return await _context.Set<Tentity>().FindAsync(key);
        }


        public async Task insertAsync(Tentity Entity)
        {
             _context.Set<Tentity>().AddAsync(Entity);
             await _context.SaveChangesAsync();
        }

        public async Task updateAsync(Tentity Entity)
        {
            _context.Set<Tentity>().Update(Entity);
            await _context.SaveChangesAsync();
        }
    }
}
