using LatDBfirstAPI.Models;
using LatDBfirstAPI.ModelV;

namespace LatDBfirstAPI.Repotitory.Contract
{
    public interface IAccountRepository :IGeneralContract<Account,string>
    {

        Task <RegisterVM> RegisterAsync(RegisterVM registerVM);
        Task<bool> LoginAsync(LoginVM loginVM);

    }
}
