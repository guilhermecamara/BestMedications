using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Database.Models
{
    public class MedicationModel : BaseModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public uint Quantity { get; set; }
    }
}