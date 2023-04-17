
namespace LatDBfirstAPI.Repotitory.Contract
{
    public interface IGeneralContract<Tentity,Key>
    {
        Task<IEnumerable<Tentity>> Getall();

       Task <Tentity>? GetbyID(Key key);
        
        Task insertAsync(Tentity Entity);
        Task updateAsync(Tentity Entity);
        Task deleteAsync(Key key);
    }
}
