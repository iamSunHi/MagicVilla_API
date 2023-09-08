using MagicT_TAPI.Repository;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaRepo : Repo<Villa>, IVillaRepo
    {
        private readonly ApplicationDbContext _context;

        public VillaRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateAsync(Villa entity)
        {
            _context.Update(entity);
            await SaveAsync();
        }
    }
}
