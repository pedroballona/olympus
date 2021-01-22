using System;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.Domain.RepositoryContracts
{
  public interface ILearningPathRepository
  {
    Task<LearningPath> Insert(LearningPath learningPath);
    Task<LearningPath> Update(Guid Id, LearningPath learningPath);
    Task Delete(Guid Id);
    Task<LearningPath> LoadById(Guid Id);
    IQueryResult<LearningPathDTO> GetAllPaginated(string filter, RequestAllOptionsDTO optionsDTO);
  }
}
