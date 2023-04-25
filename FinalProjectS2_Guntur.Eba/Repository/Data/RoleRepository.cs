using FinalProjectS2_Guntur.Eba.Contexts;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;

namespace FinalProjectS2_Guntur.Eba.Repository.Data
{
    public class RoleRepository : GeneralRepository<Role, int, MyContext>, IRoleRepository
    {
        public RoleRepository(MyContext context) : base(context) { }

    }
}
