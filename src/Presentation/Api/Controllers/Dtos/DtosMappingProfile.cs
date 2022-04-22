using AutoMapper;
using Domain.Entities;

namespace Presentation.Api.Controllers.Dtos
{
    public class DtosMappingProfile : Profile
    {
        public DtosMappingProfile()
        {
            CreateMap<Medication, MedicationDto>();
            CreateMap<CreateMedicationInputDto, Medication>();
            CreateMap<UpdateMedicationInputDto, Medication>();
        }
    }
}
