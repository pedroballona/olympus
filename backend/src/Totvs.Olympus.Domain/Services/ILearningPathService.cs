using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.Domain.Services
{
  public interface ILearningPathService
  {
    Task<LearningPath> Insert(LearningPath learningPath);
    Task<LearningPath> Update(Guid Id, LearningPath learningPath);
    Task Delete(Guid Id);
    Task<LearningPath> LoadById(Guid Id);
    IQueryResult<LearningPath> GetAllPaginated(string filter, RequestAllOptionsDTO optionsDTO);
  }
}
