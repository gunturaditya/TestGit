

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
    public class EmployeesRepository : GeneralRepository<Employee, string, MyContext>, IEmployee
    {
        private readonly IUniversity _University;
        private readonly IEducations _Education;
        private readonly IProfiling _profilling;
        private readonly IAccountRepository _account;
        private readonly IAccountRole _accountRole;
        private readonly IRole _role;
        public EmployeesRepository(MyContext context,
        IUniversity university,
        IProfiling profiling,
        IEducations educations,
        IAccountRepository account,
        IAccountRole accountRole,
        IRole role

            ) : base(context)
        {
            _University = university;
            _Education = educations;
            _profilling = profiling;
             _account = account;
            _accountRole = accountRole;
            _role = role;
        }

        public async Task<IEnumerable<EmployeesRole>> GetDataByRole(String name,int id)
        {
            var getEducation = await _Education.Getall();
            var getUniversity = await _University.Getall();
            var getProfilling = await _profilling.Getall();
            var getemployee = await Getall();
            var getAccount = await _account.Getall();
            var getAccountRole = await _accountRole.Getall();
            var getRole = await _role.Getall();

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

                           });



            return getData;
        }

        public string GetFullName(string email)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Email == email);
            if (employee == null)
                return String.Empty;

            return employee.FirstName + " " + employee.LastName;
        }


    }
}
