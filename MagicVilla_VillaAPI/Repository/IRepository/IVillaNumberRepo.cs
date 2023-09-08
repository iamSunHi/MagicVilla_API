using MagicVilla_VillaAPI.Models;

namespace MagicVilla_VillaAPI.Repository.IRepository
{
    public interface IVillaNumberRepo : IRepo<VillaNumber>
    {
        Task UpdateAsync(VillaNumber entity);
    }
}
