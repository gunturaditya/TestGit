
namespace LatDBfirstAPI.Repotitory.Contract
{
    public interface IGeneralContract<Tentity,Key>
    {
        Task<IEnumerable<Tentity>> Getall();

       Task <Tentity>? GetbyID(Key key);
        
        int insert(Tentity Entity);
        int update(Tentity Entity);
        int delete(Key key);
    }
}
