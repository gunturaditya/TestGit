using FinalProjectS2_Guntur.Eba.Contexts;
using FinalProjectS2_Guntur.Eba.Handler;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;
using FinalProjectS2_Guntur.Eba.VIewModels;

namespace FinalProjectS2_Guntur.Eba.Repository.Data
{
    public class AccountRepository : GeneralRepository<Account, string, MyContext>, IAccountRepository
    {
        private readonly IUniverityRepository _universityRepository;
        private readonly IEducationsRepository _educationRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IProfillingRepository _profilingRepository;
        private readonly IAccountRoleRepository _accountRoleRepository;

        public AccountRepository(
        MyContext context,
            IUniverityRepository universityRepository,
            IEducationsRepository educationRepository,
            IEmployeeRepository employeeRepository,
            IProfillingRepository profilingRepository,
            IAccountRoleRepository accountRoleRepository) : base(context)
        {
            _universityRepository = universityRepository;
            _educationRepository = educationRepository;
            _employeeRepository = employeeRepository;
            _profilingRepository = profilingRepository;
            _accountRoleRepository = accountRoleRepository;
        }

        public async Task RegisterAsync(RegisterVM registerVM)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var university = await _universityRepository.InsertAsync(new University
                {
                    Name = registerVM.UniversityName
                });

                var education = await _educationRepository.InsertAsync(new Education
                {
                    Major = registerVM.Major,
                    Degree = registerVM.Degree,
                    Gpa = registerVM.GPA,
                    UniversityId = university.Id,
                });

                var employee = await _employeeRepository.InsertAsync(new Employee
                {
                    Nik = registerVM.NIK,
                    FirstName = registerVM.FirstName,
                    LastName = registerVM.LastName,
                    Birthdate = registerVM.BirthDate,
                    Email = registerVM.Email,
                    PhoneNummber = registerVM.PhoneNumber,
                    Gender = registerVM.Gender,
                    HiringDate = DateTime.Now
                });

                await InsertAsync(new Account
                {
                    EmployeeNik = employee!.Nik,
                    Password = Hashing.HashPassword(registerVM.Password)
                });

                await _profilingRepository.InsertAsync(new Profiling
                {
                    EmployeeNik = employee.Nik,
                    EducationId = education!.Id
                });

                await _accountRoleRepository.InsertAsync(new AccountRole
                {
                    AccountNik = registerVM.NIK,
                    RoleId = 1
                });

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        public async Task<bool> LoginAsync(LoginVm loginVM)
        {
            var getEmployees = await _employeeRepository.GetAllAsync();
            var getAccounts = await GetAllAsync();

            var getUserData = getEmployees.Join(getAccounts,
                                                e => e.Nik,
                                                a => a.EmployeeNik,
                                                (e, a) => new LoginVm
                                                {
                                                    Email = e.Email,
                                                    Password = a.Password
                                                })
                                          .FirstOrDefault(ud => ud.Email == loginVM.Email);

            return getUserData is not null && Hashing.ValidatePassword(loginVM.Password, getUserData.Password);
        }
    }
}
