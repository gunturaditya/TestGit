

using LatDBfirstAPI.Contexts;
using LatDBfirstAPI.Models;
using LatDBfirstAPI.Repotitory.Contract;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using System.Security.Claims;


namespace LatDBfirstAPI.Repotitory.Data
{
    public class AcountRepository : GeneralRepository<Account, string,MyContext>, IAccountRepository
    {
        private readonly IUniversity _University;
        private readonly IEducations _Education;

        public AcountRepository(MyContext context, IUniversity university) : base(context)
        {
            _University = university;
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
