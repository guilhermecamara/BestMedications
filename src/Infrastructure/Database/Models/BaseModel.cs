using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Database.Models
{
    public class BaseModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
