using System;

namespace Domain.Entities
{
    public record Entity
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
