using FinalProjectS2_Guntur.Eba.Contexts;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;

namespace FinalProjectS2_Guntur.Eba.Repository.Data
{
    public class EducationsRepository : GeneralRepository<Education, int, MyContext>, IEducationsRepository
    {
       
        public EducationsRepository(MyContext context) : base(context) 
        {

        
        }
    }
}
