using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;

namespace LatDBfirstAPI.Repository.Contract
{
    public interface IAccountRole : IGeneralContract<AccountRole,int>
    {
        Task<IEnumerable<string>> GetRolesByNikAsync(string nik);
    }
}
