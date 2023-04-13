using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Security.Claims;
using WebStudy1.Context;
using WebStudy1.Models;
using WebStudy1.ModelVM;
using WebStudy1.Repotitory.Contract;

namespace WebStudy1.Repotitory.Data
{
    public class AcountRepository : GeneralRepository<Account, string, MyContext>,IAccountRepository
    {
        private  readonly IUniversity _University;
        private readonly IEducations _Education;
        public AcountRepository(MyContext context, IUniversity university) : base(context)
        {
            _University = university;
        }

        public int Login(VMLogin vMLogin)
        {
         

                var employee = new Employees
                {   
                    Email = vMLogin.Email,
                };

                _context.Employees.ToListAsync();
                _context.SaveChanges();

                var accounts = new Account
                {
                    Password = vMLogin.Password,
                    Employee_nik = employee.Nik
                };

                _context.accounts.ToListAsync();
                _context.SaveChanges();



            return _context.SaveChanges();


        }

        public int Register(RegisterVM registerVM)
        {
            // Validasi untuk input masing" entitas jika gagal lakukan rollback
            // Validasi apakah input university name ada di database/ tidak

            int commit = 0;
            try
            {
                var university = new Universities
                {
                    Name = registerVM.UniversityName,
                };
                if (university != null)
                {
                    // validasi bila ada data sama
                    var GetUniversity = _University.Getall();
                    var validasi = _context.Universities.Where(x => x.Name == university.Name).ToList();
                    if (validasi.Count == 0)
                    {
                        _context.Universities.Add(university);
                        _context.SaveChanges();
                    }
                    else
                    {
                        _context.Universities.Find(university);
                        _context.SaveChanges();

                    }

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
                    Hiring_date = DateTime.Now,
                    Role = (Role)1
                    
                };
                _context.Employees.Add(employee);
                _context.SaveChanges();

                var account = new Account
                {
                    Employee_nik = registerVM.NIK,
                    Password = registerVM.Password,
                };
                _context.accounts.Add(account);
                _context.SaveChanges();

                var profiling = new Profilings
                {
                    Employee_Nik = registerVM.NIK,
                    Education_ID = education.Id,
                };
                _context.Profilings.Add(profiling);

                commit = _context.SaveChanges();
                if (commit > 0)
                {
                    return commit;
                }
            }
            catch
            {
                return 0;
            }

            return commit;
        }
    }
}
