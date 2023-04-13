using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Repotitory.Data
{
    public class ProfilingRepository : GeneralRepository<Profilings, string, MyContext>, IProfiling
    {
        public ProfilingRepository(MyContext context) : base(context)
        {
        }
    }
}
