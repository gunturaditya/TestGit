using Microsoft.EntityFrameworkCore;
using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Repotitory.Data
{
    public class EducationsRepository : GeneralRepository<Educations, int, MyContext>, IEducations
    {
        public EducationsRepository(MyContext context) : base(context)
        {
        }
    }
}
