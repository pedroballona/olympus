using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.RepositoryContracts;

namespace Totvs.Olympus.API.Controllers
{
  [ApiController]
  [ApiVersion("1.0")]
  [Route("api/v{version:apiVersion}/users")]
  public class UserController : ControllerBase
  {
    private readonly IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
      _repository = repository;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Route("me")]
    public async Task<UserDTO> GetLoggedUser()
    {
      return await _repository.GetLoggedUser();
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    public IQueryResult<UserDTO> GetAllUsers([FromQuery] string filter, 
                                             [FromQuery] RequestAllOptionsDTO options)
    {
      return _repository.GetAllUsers(filter, options);
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [Route("{id}")]
    public async Task<UserDTO> GetUserById([Required] Guid id)
    {
      return await _repository.GetUserById(id);
    }

    [HttpPost]
    [MapToApiVersion("1.0")]
    public async Task<UserDTO> CreateUser([FromBody] UserInputDTO inputDTO)
    {
      return await _repository.CreateUser(inputDTO);
    }

    [HttpPut]
    [MapToApiVersion("1.0")]
    [Route("{id}")]
    public async Task<UserDTO> UpdateUser([Required] Guid id, 
                                          [FromBody] UserInputDTO inputDTO)
    {
      return await _repository.UpdateUser(id, inputDTO);
    }

    [HttpPut]
    [MapToApiVersion("1.0")]
    [Route("{id}/courses")]
    public async Task<UserDTO> AddNewCourseToUser([Required] Guid id,
                                                  [FromBody] Guid newCourseId)
    {
      return await _repository.AddNewCourseToUser(id, newCourseId);
    }

    [HttpPut]
    [MapToApiVersion("1.0")]
    [Route("{id}/learning-paths")]
    public async Task<UserDTO> AddNewLearningPath([Required] Guid id,
                                                  [FromBody] Guid newLearningPathId)
    {
      return await _repository.AddNewCourseToUser(id, newLearningPathId);
    }

    [HttpDelete]
    [MapToApiVersion("1.0")]
    [Route("{id}")]
    public async Task<NoContentResult> DeleteUser([Required] Guid id)
    {
      await _repository.DeleteUser(id);
      return NoContent();
    }
  }
}
