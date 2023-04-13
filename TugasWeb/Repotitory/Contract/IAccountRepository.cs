using WebStudy1.Models;
using WebStudy1.ModelVM;

namespace WebStudy1.Repotitory.Contract
{
    public interface IAccountRepository :IGeneralContract<Account,string>
    {
        int Register(RegisterVM registerVM);
        int Login(VMLogin vMLogin);
    }
}
