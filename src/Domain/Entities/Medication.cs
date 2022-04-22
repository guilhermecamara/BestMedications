
namespace Domain.Entities
{
    public record Medication : Entity
    {
        public string Name { get; set; }
        public uint Quantity { get; set; }
    }
}