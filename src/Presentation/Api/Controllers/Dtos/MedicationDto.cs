using System;

namespace Presentation.Api.Controllers.Dtos
{
    public record MedicationDto
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Name { get; set; }
        public uint Quantity { get; set; }
    }
}
