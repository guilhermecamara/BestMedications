using AutoMapper;
using Domain.Entities;
using Domain.Errors;
using Domain.Repositories;
using Infrastructure.Database;
using Infrastructure.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class MedicationRepository : IMedicationRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public MedicationRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public IEnumerable<Medication> GetAll()
        {
            return _dbContext.Medications.Select(p => _mapper.Map<Medication>(p)).ToList();
        }

        public Medication Get(Guid id)
        {
            var medicationModel = _dbContext.Medications.AsQueryable().FirstOrDefault(p => p.Id.Equals(id));
            if (medicationModel == null)
            {
                throw new EntityNotFoundException(nameof(Medication), id);
            }
            return _mapper.Map<Medication>(medicationModel);
        }

        public Medication Create(Medication medication)
        {
            medication.Id = Guid.NewGuid();            
            var medicationModel = _mapper.Map<MedicationModel>(medication);
            
            _dbContext.Medications.Add(medicationModel);
            _dbContext.SaveChanges();

            return Get(medication.Id.Value);
        }

        public Medication Update(Medication medication)
        {
            var medicationModel = _dbContext.Medications.AsQueryable().FirstOrDefault(p => p.Id.Equals(medication.Id.Value));
            if (medicationModel == null)
            {
                throw new EntityNotFoundException(nameof(Medication), medication.Id.Value);
            }

            medicationModel.Name = medication.Name;
            medicationModel.Quantity = medication.Quantity;

            _dbContext.SaveChanges();

            return _mapper.Map<Medication>(medicationModel);
        }

        public bool Delete(Guid id)
        {
            var medicationModel = _dbContext.Medications.AsQueryable().FirstOrDefault(p => p.Id.Equals(id));
            if (medicationModel == null)
            {
                return false;
            }

            _dbContext.Medications.Remove(medicationModel);
            _dbContext.SaveChanges();

            return true;
        }
    }
}