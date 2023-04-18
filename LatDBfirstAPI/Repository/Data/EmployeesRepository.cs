

using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Controllers;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.ModelV;
using LatDBfirstAPI.Repository.Contract;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Linq;

namespace LatDBfirstAPI.Repotitory.Data
{
    public class EmployeesRepository : GeneralRepository<Employee, string, MyContext>,IEmployee
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUniversity _univerity;
        private readonly IEducations _educations;
        private readonly IProfiling _profiling;
        private readonly IAccountRole _accountRole;
        private readonly IRole _role;

        public EmployeesRepository(MyContext context
            ) : base(context)
        {
     
        }

        public async Task<IEnumerable<EmployeesRole>> GetDataByRole(string name, int id)
        {
        

            var getData = (from e in _context.Educations
                           join u in _context.Universities
                          on e.UniversityId equals u.Id
                           join p in _context.Profilings
                           on e.Id equals p.EducationId
                           join em in _context.Employees
                           on p.EmployeeNik equals em.Nik
                           join ac in _context.Accounts
                           on em.Nik equals ac.EmployeeNik
                           join acr in _context.AccountRoles
                           on ac.EmployeeNik equals acr.AccountNik
                           join r in _context.Roles
                           on acr.RoleId equals r.Id
                           where u.Name == name && acr.RoleId == id
                           orderby e.Gpa descending
                           select new EmployeesRole()
                           {
                               Nik = p.EmployeeNik,
                               Universitas = u.Name,
                               NameEmployee = em.FirstName + " " + em.LastName,
                               Gpa = e.Gpa,
                               AccountRole = r.Name

                           }).ToListAsync();

            return await getData;
        }

/*             public async Task<IEnumerable<EmployeesRole>> GetDataByRole(String name,int id)
                {
                    var getEducation = await _educations.GetallAsync();
                    var getUniversity = await _univerity.GetallAsync();
                    var getProfilling = await _profiling.GetallAsync();
                    var getemployee = await GetallAsync();
                    var getAccount = await _accountRepository.GetallAsync();
                    var getAccountRole = await _accountRole.GetallAsync();
                    var getRole = await _role.GetallAsync();

                    var getData = (from e in getEducation
                                   join u in getUniversity
                                  on e.UniversityId equals u.Id
                                   join p in getProfilling
                                   on e.Id equals p.EducationId
                                   join em in getemployee
                                   on p.EmployeeNik equals em.Nik
                                   join ac in getAccount
                                   on em.Nik equals ac.EmployeeNik
                                   join acr in getAccountRole
                                   on ac.EmployeeNik equals acr.AccountNik
                                   join r in getRole
                                   on acr.RoleId equals r.Id
                                   where u.Name == name && acr.RoleId == id
                                   orderby e.Gpa descending
                                   select new EmployeesRole()
                                   {
                                       Nik = p.EmployeeNik,
                                       Universitas = u.Name,
                                       NameEmployee = em.FirstName + " " + em.LastName,
                                       Gpa = e.Gpa,
                                       AccountRole = r.Name

                                   }).ToList();

                    return getData;
                }*/



        public async Task<string> GetFullNameByEmailAsync(string email)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            return employee is null ? string.Empty : string.Concat(employee.FirstName, " ", employee.LastName);
        }
    }
}
