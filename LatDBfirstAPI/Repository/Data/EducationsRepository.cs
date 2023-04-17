
using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;

namespace LatDBfirstAPI.Repotitory.Data
{
    public class EducationsRepository : GeneralRepository<Education, int, MyContext>, IEducations
    {
        public EducationsRepository(MyContext context) : base(context)
        {
        }
    }
}
