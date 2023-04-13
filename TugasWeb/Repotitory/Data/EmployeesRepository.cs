using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Repotitory.Data
{
    public class EmployeesRepository : GeneralRepository<Employees, string, MyContext>, IEmployee
    {
        public EmployeesRepository(MyContext context) : base(context)
        {
        }
    }
}
