using System;

namespace Presentation.Api.Controllers.Dtos
{
    public record UpdateMedicationInputDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public uint Quantity { get; set; }
    }
}
