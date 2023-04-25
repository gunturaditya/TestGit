using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.VIewModels;

namespace FinalProjectS2_Guntur.Eba.Repository.Contract
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, string>
    {
        Task<UserdataVM> GetUserDataByEmailAsync(string email);
        Task<IEnumerable<EmployeesEducationVM>> GetEmployeeEducation();
        Task<IEnumerable<EmployeesEducationVM>> GetAvarage(int tahun);

        Task<IEnumerable<EmployeeCountVM>> GetEmployeesCount();

        Task<IEnumerable<EmployeeDaysWork>> getEmployeeWorkDays();
    }
}
