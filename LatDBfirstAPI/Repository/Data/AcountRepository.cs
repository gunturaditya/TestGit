

using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Handler;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.ModelV;
using LatDBfirstAPI.Repository.Contract;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System.Security.Claims;

namespace LatDBfirstAPI.Repotitory.Data
{
    public class AcountRepository : GeneralRepository<Account,string,MyContext>,IAccountRepository
    {
        private readonly IUniversity _University;
        private readonly IEducations _Education;
        private readonly IProfiling _profilling;
        private readonly IEmployee _employee;
        private readonly IAccountRole _accountRole;


        public AcountRepository(MyContext context,
        IUniversity university,
        IProfiling profiling,
        IEducations educations,
        IEmployee employee,
        IAccountRole accountRole
         ) : base(context)
        {
            _University = university;
            _Education = educations;
            _profilling = profiling;
            _employee = employee;
            _accountRole = accountRole;
        }

        public async Task<bool> LoginAsync(LoginVM loginVM)
        {
            var getdataEmployee = await _employee.GetallAsync();
            var GetdataAccount = await GetallAsync();

           var getdataLogin = getdataEmployee.Join(GetdataAccount,
                            e => e.Nik,
                            a => a.EmployeeNik,
                            (e, a) => new LoginVM
                            {
                               Email = e.Email,
                               Password = a.Password,
                            }).FirstOrDefault(ud => ud.Email == loginVM.Email);
            return getdataLogin is not null && Hashing.ValidatePassword(loginVM.Password, getdataLogin.Password);
        }

        public async Task<RegisterVM> RegisterAsync(RegisterVM registerVM)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var university = new University
                {
                    Name = registerVM.UniversityName
                };
                      if(await _University.IsNameExist(registerVM.UniversityName))
                     {

                     }
                      else
                      {
                          await _University.InsertAsync(university);
                       }
                var education = new Education()
                {
                    Degree = registerVM.Degree,
                    Major = registerVM.Major,
                    Gpa = registerVM.GPA,
                    UniversityId = university.Id
                };
                await _Education.InsertAsync(education);

                var employee = new Employee()
                {
                    Birthdate = registerVM.BirthDate,
                    Email = registerVM.Email,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Gender = registerVM.Gender,
                    HiringDate = DateTime.Now,
                    Nik = registerVM.NIK,
                    PhoneNummber = registerVM.PhoneNumber
                };
                await _employee.InsertAsync(employee);
                var profiling = new Profiling()
                {
                    EducationId = education.Id,
                    EmployeeNik = employee.Nik
                };
                await _profilling.InsertAsync(profiling);
                var account = new Account()
                {
                    EmployeeNik = employee.Nik,
                    Password = Hashing.HashPassword(registerVM.Password)
                };
                await InsertAsync(account);

                var accountrole = new AccountRole()
                {
                    AccountNik = account.EmployeeNik,
                    RoleId = 1
                };
                await _accountRole.InsertAsync(accountrole);
                await transaction.CommitAsync();
                return registerVM; 
            }catch(Exception ex)
            {
                transaction.Rollback();
            }
            return null;
        }









        /*     public bool Login(VMLogin vMLogin)
             {
                 var getUserData = _context.Employees.Join(_context.accounts, e => e.Nik, a => a.Employee_nik, (e, a) => new VMLogin
                 {
                     Email = e.Email,
                     Password = a.Password
                 }).FirstOrDefault(e => e.Email == vMLogin.Email);

                 return getUserData is not null && Hashing.ValidatePassword(vMLogin.Password, getUserData.Password);

             }


             public int Register(RegisterVM registerVM)
             {
                 // Validasi untuk input masing" entitas jika gagal lakukan rollback
                 using var transaction = _context.Database.BeginTransaction();
                 try
                 {
                     Universities university = new Universities
                     {
                         Name = registerVM.UniversityName
                     };

                     // Bikin kondisi untuk mengecek apakah data university sudah ada
                     if (_context.Universities.Any(u => u.Name == university.Name))
                     {
                         university.Id = _context.Universities
                                                 .First(u => u.Name == university.Name)
                                                 .Id;
                     }
                     else
                     {
                         _context.Universities.Add(university);
                         _context.SaveChanges();
                     }

                     var education = new Educations
                     {
                         Major = registerVM.Major,
                         Degree = registerVM.Degree,
                         Gpa = registerVM.GPA,
                         Universitas_id = university.Id,
                     };
                     _context.Educations.Add(education);
                     _context.SaveChanges();

                     var employee = new Employees
                     {
                         Nik = registerVM.NIK,
                         First_name = registerVM.FirstName,
                         Last_name = registerVM.LastName,
                         Birthdate = registerVM.BirthDate,
                         EmployeeGender = registerVM.Gender,
                         Phone = registerVM.PhoneNumber,
                         Email = registerVM.Email,
                         Hiring_date = DateTime.Now
                     };
                     _context.Employees.Add(employee);
                     _context.SaveChanges();

                     var account = new Account
                     {
                         Employee_nik = registerVM.NIK,
                         Password = Hashing.HashPassword(registerVM.Password),
                     };
                     _context.accounts.Add(account);
                     _context.SaveChanges();

                     var profiling = new Profilings
                     {
                         Employee_Nik = registerVM.NIK,
                         Education_ID = education.Id,
                     };
                     _context.Profilings.Add(profiling);
                     _context.SaveChanges();

                     var accountRole = new Account_Roles
                     {
                         Account_nik = registerVM.NIK,
                         Role_id = 1
                     };
                     _context.account_roles.Add(accountRole);
                     _context.SaveChanges();
                     transaction.Commit();

                     return 1;
                 }
                 catch
                 {
                     transaction.Rollback();
                     return 0;
                 }
             }*/
    }
}
