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
        public  int delete(Key key)
        {
            var entity = _context.Set<Tentity>().Find(key);
            if (entity == null)
            {

            }
            _context.Set<Tentity>().Remove(entity);
            return _context.SaveChanges();

        }

        public async Task< IEnumerable<Tentity>> Getall()
        {
            return await _context.Set<Tentity>().ToListAsync();
        }

        public async Task<Tentity>? GetbyID(Key key)
        {
            return await _context.Set<Tentity>().FindAsync(key);
        }


        public int insert(Tentity Entity)
        {
            _context.Set<Tentity>().Add(Entity);
            return _context.SaveChanges();
        }

        public int update(Tentity Entity)
        {
            _context.Set<Tentity>().Update(Entity);
            return _context.SaveChanges();
        }
    }
}
