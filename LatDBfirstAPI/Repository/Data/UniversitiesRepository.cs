

using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.EntityFrameworkCore;

namespace LatDBfirstAPI.Repotitory.Data
{
    public class UniversitiesRepository : GeneralRepository<University, int, MyContext>, IUniversity
    {
        public UniversitiesRepository(MyContext context) : base(context)
        {

        }

        public async Task<bool> IsNameExist(string name)
        {
            var entity = await _context.Set<University>().FirstOrDefaultAsync(x => x.Name == name);
            return entity != null;
        }
    }
}
