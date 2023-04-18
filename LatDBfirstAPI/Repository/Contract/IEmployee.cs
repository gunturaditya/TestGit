using LatDBfirstAPI.Controllers;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.ModelV;

namespace LatDBfirstAPI.Repotitory.Contract
{
    public interface IEmployee : IGeneralContract<Employee, string>
    {
        Task<string> GetFullNameByEmailAsync(string email);

        Task<IEnumerable<EmployeesRole>> GetDataByRole(String name, int id);
    }
}
