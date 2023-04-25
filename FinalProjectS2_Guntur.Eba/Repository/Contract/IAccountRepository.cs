using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.VIewModels;

namespace FinalProjectS2_Guntur.Eba.Repository.Contract
{
    public interface IAccountRepository : IGeneralRepository<Account, string>
    {
        Task RegisterAsync(RegisterVM registerVM);
        Task<bool> LoginAsync(LoginVm loginVM);
    }
}
