using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaRepo : IRepo<Villa>
    {
        Task UpdateAsync(Villa entity);
    }
}
