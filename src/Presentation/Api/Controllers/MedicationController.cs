using AutoMapper;
using Domain.Entities;
using Domain.UseCases.Medications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Presentation.Api.Controllers.Dtos;

namespace Presentation.Api.Controllers
{
    [ApiController]
    [Route("medications")]
    public class MedicationController : CrudController<Medication, MedicationDto, CreateMedicationInputDto, UpdateMedicationInputDto, IGetAllMedicationsUseCase, IGetMedicationByIdUseCase, ICreateMedicationUseCase, IUpdateMedicationUseCase, IDeleteMedicationUseCase>
    { 
        public MedicationController(ILogger<MedicationController> logger, IMapper mapper, IGetAllMedicationsUseCase getAllMedicationsUseCase, IGetMedicationByIdUseCase getMedicationUseCase, ICreateMedicationUseCase createMedicationUseCase, IUpdateMedicationUseCase updateMedicationUseCase, IDeleteMedicationUseCase deleteMedicationUseCase) : base(logger, mapper, getAllMedicationsUseCase, getMedicationUseCase, createMedicationUseCase, updateMedicationUseCase, deleteMedicationUseCase)
        {
        }
    }
}