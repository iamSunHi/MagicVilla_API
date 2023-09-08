using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaNumberDTO
    {
        public int VillaNo { get; set; }

        public int VillaID { get; set; }
        public VillaDTO Villa { get; set; } = null!;

        public string? SpecialDetails { get; set; }
    }
}
