using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Repotitory.Data
{
    public class UniversitiesRepository : GeneralRepository<Universities, int, MyContext>, IUniversity
    {
        public UniversitiesRepository(MyContext context) : base(context)
        {

        }
    }
}
