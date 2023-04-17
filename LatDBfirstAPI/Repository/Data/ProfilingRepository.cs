

using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;

namespace LatDBfirstAPI.Repotitory.Data
{
    public class ProfilingRepository : GeneralRepository<Profiling, string, MyContext>, IProfiling
    {
        public ProfilingRepository(MyContext context) : base(context)
        {
        }
    }
}
