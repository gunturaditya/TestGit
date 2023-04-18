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
        public async Task<Tentity> deleteAsync(Key key)
        {
            var entity = await GetbyIDAsync(key);
             _context.Set<Tentity>().Remove(entity!);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task< IEnumerable<Tentity>> GetallAsync()
        {
            return await _context.Set<Tentity>().ToListAsync();
        }

        public async Task<Tentity>? GetbyIDAsync(Key key)
        {
            return await _context.Set<Tentity>().FindAsync(key);
        }


        public virtual async Task<Tentity?> InsertAsync(Tentity entity)
        {
            _context.Set<Tentity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task updateAsync(Tentity Entity)
        {
            _context.Set<Tentity>().Update(Entity);
            await _context.SaveChangesAsync();
        }
    }
}
