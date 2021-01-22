using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;
using Totvs.Olympus.Domain.Services;

namespace Totvs.Olympus.API.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/learning-path")]
  public class LearningPathController : ControllerBase
  {
    private readonly ILearningPathService _service;

    public LearningPathController(ILearningPathService service)
    {
      _service = service;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public IQueryResult<LearningPathDTO> GetAll([FromQuery] string filter, [FromQuery] RequestAllOptionsDTO optionsDTO)
    {
      var result = _service.GetAllPaginated(filter, optionsDTO);
      return result;
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<LearningPath> Insert([FromBody] LearningPathDTO learningPathDTO)
    {
      var learningPath = new LearningPath(learningPathDTO);
      var result = await _service.Insert(learningPath);

      return result;
    }

    [HttpPut]
    [MapToApiVersion("1.0")]
    [Route("{id}")]
    public async Task<LearningPath> Update(Guid Id, [FromBody] LearningPathDTO learningPathDTO)
    {
      var learningPath = new LearningPath(learningPathDTO);
      var result = await _service.Update(Id, learningPath);

      return result;
    }

    [HttpDelete]
    [MapToApiVersion("1.0")]
    [Route("{id}")]
    public async Task<NoContentResult> Delete(Guid Id)
    {
      await _service.Delete(Id);
      return NoContent();
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Route("{id}")]
    public async Task<LearningPath> GetById(Guid id)
    {
      var result = await _service.LoadById(id);
      return result;
    }
  }
}
