using System.ComponentModel.DataAnnotations;

namespace MagicVilla_VillaAPI.Models.DTO
{
    public class VillaNumberUpdateDTO
    {
        public int VillaNo { get; set; }

        public int VillaID { get; set; }

        public string? SpecialDetails { get; set; }
    }
}
