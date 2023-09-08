using MagicT_TAPI.Repository;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaNumberRepo : Repo<VillaNumber>, IVillaNumberRepo
    {
        private readonly ApplicationDbContext _context;

        public VillaNumberRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateAsync(VillaNumber entity)
        {
            _context.VillaNumbers.Update(entity);
            await SaveAsync();
        }
    }
}
