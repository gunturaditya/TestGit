

using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;

namespace LatDBfirstAPI.Repotitory.Data
{
    public class UniversitiesRepository : GeneralRepository<University, int, MyContext>, IUniversity
    {
        public UniversitiesRepository(MyContext context) : base(context)
        {

        }
    }
}
