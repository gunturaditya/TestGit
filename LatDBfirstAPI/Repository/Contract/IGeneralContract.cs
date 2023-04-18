
namespace LatDBfirstAPI.Repotitory.Contract
{
    public interface IGeneralContract<Tentity,Key>
    {
        Task<IEnumerable<Tentity>> GetallAsync();

       Task <Tentity>? GetbyIDAsync(Key key);

        Task<Tentity?> InsertAsync(Tentity entity);
        Task<Tentity> updateAsync(Tentity Entity);
        Task<Tentity> deleteAsync(Key key);
    }
}
