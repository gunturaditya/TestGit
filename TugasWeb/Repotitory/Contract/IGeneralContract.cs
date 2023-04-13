using WebStudy1.Models;

namespace WebStudy1.Repotitory.Contract
{
    public interface IGeneralContract<Tentity,Key>
    {
        IEnumerable<Tentity> Getall();

        Tentity? GetbyID(Key key);
        
        int insert(Tentity Entity);
        int update(Tentity Entity);
        int delete(Key key);
    }
}
