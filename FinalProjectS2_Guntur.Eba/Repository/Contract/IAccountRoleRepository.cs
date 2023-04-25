using FinalProjectS2_Guntur.Eba.Models;

namespace FinalProjectS2_Guntur.Eba.Repository.Contract
{
    public interface IAccountRoleRepository : IGeneralRepository<AccountRole, int>
    {
        Task<IEnumerable<string>> GetRolesByNikAsync(string nik);
    }
}
