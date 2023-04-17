using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repository.Contract;
using LatDBfirstAPI.Repotitory;

namespace LatDBfirstAPI.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int, MyContext>, IAccountRole
    {
        public AccountRoleRepository(MyContext context) : base(context)
        {
        }
    }
}
