using FinalProjectS2_Guntur.Eba.Contexts;
using FinalProjectS2_Guntur.Eba.Models;
using FinalProjectS2_Guntur.Eba.Repository.Contract;
using FinalProjectS2_Guntur.Eba.VIewModels;


namespace FinalProjectS2_Guntur.Eba.Repository.Data
{
    public class ProfillingRepository : GeneralRepository<Profiling, string, MyContext>, IProfillingRepository
    {
       
        public ProfillingRepository(MyContext context) :
            base(context)
        {
           
        }


    }
}
