using FinalProjectS2_Guntur.Eba.Contexts;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;
using FinalProjectS2_Guntur.Eba.VIewModels;
using Microsoft.EntityFrameworkCore;


namespace FinalProjectS2_Guntur.Eba.Repository.Data
{
    public class EmployeeRepository : GeneralRepository<Employee, string, MyContext>, IEmployeeRepository
    {
        private readonly IUniverityRepository _univerityRepository;
        private readonly IEducationsRepository _educationsRepository;
        private readonly IProfillingRepository _profillingRepository;
        public EmployeeRepository(MyContext context, 
            IUniverityRepository univerityRepository, 
            IEducationsRepository educationsRepository, 
            IProfillingRepository profillingRepository) : base(context) 
        {
            _educationsRepository = educationsRepository;
            _profillingRepository = profillingRepository;
            _univerityRepository = univerityRepository;
        }

        public async Task<IEnumerable<EmployeesEducationVM>> GetAvarage(int tahun)
        {
            var getEmployee = await GetEmployeeEducation();
            var AvarageEmployee = getEmployee.Average(x => x.GPA);
            var dataEmployee = from Em in getEmployee
                                where Em.Hiring.Year == tahun && Em.GPA > AvarageEmployee
                                select new EmployeesEducationVM
                                {
                                    Nik = Em.Nik,
                                    Name = Em.Name,
                                    Hiring = Em.Hiring,
                                    GPA = Em.GPA,
                                    Major = Em.Major,
                                    University = Em.University
                                };

            return dataEmployee;
        }

        public async Task<IEnumerable<EmployeesEducationVM>> GetEmployeeEducation()
        {
            var education = await _educationsRepository.GetAllAsync();
            var university = await _univerityRepository.GetAllAsync();
            var profiling = await _profillingRepository.GetAllAsync();
            var employee = await GetAllAsync();

            var data = from ed in education
                       join un in university on ed.UniversityId equals un.Id
                       join pr in profiling on ed.Id equals pr.EducationId
                       join em in employee on pr.EmployeeNik equals em.Nik
                       select new EmployeesEducationVM()
                       {
                           Nik = em.Nik,
                           Name = string.Concat(em.FirstName + " " + em.LastName),
                           University = un.Name,
                           Major = ed.Major,
                           GPA = ed.Gpa,
                           Hiring = em.HiringDate
                           
                       };

            return data;
                             
        }

        public async Task<IEnumerable<EmployeeCountVM>> GetEmployeesCount()
        {
            var employee = await GetEmployeeEducation();
            var getCount = (from em in employee
                           orderby em.University ascending
                           group em by ( em.Major,em.University) into g
                           select new EmployeeCountVM()
                           {

                               University = g.First().University,
                               Major = g.First().Major,
                               Count = g.Count()

                           });
            return getCount;
                          
        }

        public async Task<IEnumerable<EmployeeDaysWork>> getEmployeeWorkDays()
        {
            var employee = await GetAllAsync();
            var data = (from emp in employee
                       let daywork = DateTime.Now.Date.Subtract((DateTime)emp.HiringDate).TotalDays
                       orderby daywork descending
                       select new EmployeeDaysWork
                       {
                           Nik = emp.Nik,
                           Name = emp.FirstName+" "+emp.LastName,
                           hiring = emp.HiringDate,
                           Gender = emp.Gender,
                           DayWork = Convert.ToInt32(daywork)
                       });

            return data;

        }

        public async Task<UserdataVM> GetUserDataByEmailAsync(string email)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.Email == email);
            return new UserdataVM
            {
                Nik = employee!.Nik,
                Email = employee.Email,
                FullName = string.Concat(employee.FirstName, " ", employee.LastName)
            };
        }
    }

}
