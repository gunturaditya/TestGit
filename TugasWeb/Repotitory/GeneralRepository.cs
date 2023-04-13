using System.Xml.Linq;
using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Repotitory
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
        public int delete(Key key)
        {
            var entity = GetbyID(key);
            if (entity == null)
            {
                return 0;
            }
            _context.Set<Tentity>().Remove(entity);
            return _context.SaveChanges();
        }

        public IEnumerable<Tentity> Getall()
        {
            return _context.Set<Tentity>().ToList();
        }

        public Tentity? GetbyID(Key key)
        {
            return _context.Set<Tentity>().Find(key);
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
