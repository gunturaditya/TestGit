using FinalProjectS2_Guntur.Eba.Models;

namespace FinalProjectS2_Guntur.Eba.Repository.Contract
{
    public interface IUniverityRepository : IGeneralRepository<University, int>
    {
        Task<University?> GetByNameAsync(string name);
        Task<bool> IsNameExistAsync(string name);
    }
}
