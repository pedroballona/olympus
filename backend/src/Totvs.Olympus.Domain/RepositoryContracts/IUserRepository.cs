using System;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.Domain.RepositoryContracts
{
  public interface IUserRepository
  {
    Task<UserDTO> GetLoggedUser();
    IQueryResult<UserDTO> GetAllUsers(string filter, RequestAllOptionsDTO options);
    Task<UserDTO> GetUserById(Guid id);
    Task<UserDTO> CreateUser(UserInputDTO inputDTO);
    Task<UserDTO> UpdateUser(Guid id, UserInputDTO inputDTO);
    Task<UserDTO> AddNewCourseToUser(Guid id, Guid newCourseId);
    Task<UserDTO> AddNewLearningPath(Guid id, Guid newLearningPathId);
    Task DeleteUser(Guid id);
  }
}
