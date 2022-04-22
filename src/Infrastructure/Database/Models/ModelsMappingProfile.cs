using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Database.Models
{
    public class ModelsMappingProfile : Profile
    {
        public ModelsMappingProfile()
        {
            CreateMap<Medication, MedicationModel>()
                .ForMember(dest =>
                    dest.CreationDate,
                    opt => opt.Ignore());
            CreateMap<MedicationModel, Medication>();
        }
    }
}
