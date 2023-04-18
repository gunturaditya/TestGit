using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repository.Contract;
using LatDBfirstAPI.Repotitory;

namespace LatDBfirstAPI.Repository.Data
{
    public class RoleRepository : GeneralRepository<Role, int, MyContext>,IRole
    {
        public RoleRepository(MyContext context) : base(context)
        {
        }
    }
}
