using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repository.Contract;
using LatDBfirstAPI.Repotitory;

namespace LatDBfirstAPI.Repository.Data
{
    public class AccountRoleRepository : GeneralRepository<AccountRole, int, MyContext>, IAccountRole
    {
        private readonly IRole _role;
        public AccountRoleRepository(MyContext context, IRole role) : base(context)
        {
            _role = role;
        }

        public async Task<IEnumerable<string>> GetRolesByNikAsync(string nik)
        {
            var getAccountRoleByAccountNik = GetallAsync().Result.Where(x => x.AccountNik == nik);
            var getRole = await _role.GetallAsync();

            var getRoleByNik = from ar in getAccountRoleByAccountNik
                               join r in getRole on ar.RoleId equals r.Id
                               select r.Name;

            return getRoleByNik;
        }
    }
}
