

using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Controllers;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.ModelV;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LatDBfirstAPI.Repotitory.Data
{
    public class EmployeesRepository : GeneralRepository<Employee, string, MyContext>, IEmployee
    {
        public EmployeesRepository(MyContext context) : base(context)
        {

        }

        public async Task<IEnumerable<EmployeesRole>> GetDataByRole(String name,int id)
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
                              NameEmployee = em.FirstName+" "+em.LastName,
                              Gpa = e.Gpa,
                              AccountRole = r.Name

                           
                          }).ToListAsync();



            return await getData;
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
