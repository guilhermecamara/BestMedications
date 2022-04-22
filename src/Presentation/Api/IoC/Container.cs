using Domain.Repositories;
using Domain.UseCases.Medications;
using Domain.UseCases.Medications.Validators;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Api.IoC
{
    public static class Container
    {
        public static void ConfigureIoC(IServiceCollection services)
        {
            ConfigureUseCases(services);
            ConfigureValidators(services);
            ConfigureRepositories(services);
        }

        public static void ConfigureUseCases(IServiceCollection services)
        {
            services.AddTransient<ICreateMedicationUseCase, CreateMedicationUseCase>();
            services.AddTransient<IDeleteMedicationUseCase, DeleteMedicationUseCase>();
            services.AddTransient<IGetAllMedicationsUseCase, GetAllMedicationsUseCase>();
            services.AddTransient<IGetMedicationByIdUseCase, GetMedicationByIdUseCase>();
            services.AddTransient<IUpdateMedicationUseCase, UpdateMedicationUseCase>();
        }

        public static void ConfigureValidators(IServiceCollection services)
        {
            services.AddTransient<ICreateMedicationValidator, CreateMedicationValidator>();
            services.AddTransient<IUpdateMedicationValidator, UpdateMedicationValidator>();         
        }

        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IMedicationRepository, MedicationRepository>();
        }
    }
}
