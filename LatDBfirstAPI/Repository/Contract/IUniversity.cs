using LatDBfirstAPI.Models;



namespace LatDBfirstAPI.Repotitory.Contract
{
    public interface IUniversity : IGeneralContract<University,int>
    {
        Task<bool> IsNameExist(string name);
        Task<University?> GetByNameAsync(string name);
    }
}
