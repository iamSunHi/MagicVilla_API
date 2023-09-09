using MagicVilla_Web.Models.DTO;

namespace MagicVilla_Web.Services.IServices
{
    public interface IVillaService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int id);
        Task<T> CreateAsync<T>(VillaCreateDTO createDTO);
        Task<T> UpdateAsync<T>(VillaUpdateDTO updateDTO);
        Task<T> DeleteAsync<T>(int id);
    }
}
