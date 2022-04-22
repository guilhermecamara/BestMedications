namespace Presentation.Api.Controllers.Dtos
{
    public record CreateMedicationInputDto
    {
        public string Name { get; set; }
        public uint Quantity { get; set; }
    }
}
