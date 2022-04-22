using AutoMapper;
using Domain.Entities;
using Domain.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Presentation.Api.Controllers
{
    public abstract class CrudController<TEntity, TEntityDto, TCreateEntityDto, TUpdateEntityDto, TGetAllUseCase, TGetUseCase, TCreateUseCase, TUpdateUseCase, TDeleteUseCase> : ControllerBase where TEntity : Entity where TGetAllUseCase : IGetAllEntitiesUseCase<TEntity> where TGetUseCase : IGetEntityUseCase<TEntity> where TCreateUseCase : ICreateEntityUseCase<TEntity, TEntity> where TUpdateUseCase : IUpdateEntityUseCase<TEntity, TEntity> where TDeleteUseCase : IDeleteEntityUseCase
    {
        protected readonly ILogger _logger;
        protected readonly IMapper _mapper;
        private readonly TGetAllUseCase _getAllUseCase;
        private readonly TGetUseCase _getUseCase;
        private readonly TCreateUseCase _createUseCase;
        private readonly TUpdateUseCase _updateUseCase;
        private readonly TDeleteUseCase _deleteUseCase;

        public CrudController(ILogger logger, IMapper mapper, TGetAllUseCase getAllUseCase, TGetUseCase getUseCase, TCreateUseCase createUseCase, TUpdateUseCase updateUseCase, TDeleteUseCase deleteUseCase)
        {
            _logger = logger;
            _mapper = mapper;
            _getAllUseCase = getAllUseCase;
            _getUseCase = getUseCase;
            _createUseCase = createUseCase;
            _updateUseCase = updateUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TEntityDto>> GetAll()
        {
            var output = _getAllUseCase.execute();
            return Ok(output.Select(dto => _mapper.Map<TEntityDto>(dto)).ToList());
        }

        [HttpGet("{id:guid}")]
        public ActionResult<TEntityDto> Get([FromRoute] Guid id)
        {
            var output = _getUseCase.execute(id);
            return Ok(_mapper.Map<TEntityDto>(output));
        }

        [HttpPost]
        public ActionResult<TEntityDto> Post([FromBody] TCreateEntityDto input)
        {
            var output = _createUseCase.execute(_mapper.Map<TEntity>(input));
            return Ok(_mapper.Map<TEntityDto>(output));
        }

        [HttpPut]
        public ActionResult<TEntityDto> Put([FromBody] TUpdateEntityDto input)
        {
            var output = _updateUseCase.execute(_mapper.Map<TEntity>(input));
            return Ok(_mapper.Map<TEntityDto>(output));
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _deleteUseCase.execute(id);
            return Ok();
        }
    }
}