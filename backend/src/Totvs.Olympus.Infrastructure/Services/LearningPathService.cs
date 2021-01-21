using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;
using Totvs.Olympus.Domain.Services;
using Totvs.Olympus.Infrastructure.Adapter;
using Totvs.Olympus.Infrastructure.Models;

namespace Totvs.Olympus.Infrastructure.Services
{
  public class LearningPathService : ILearningPathService
  {
    private readonly IMongoCollection<LearningPath> _collection;
    private readonly IMapper _mapper;

    public LearningPathService(IOlympusDatabaseSettings settings,
                               IMapper mapper)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _collection = database.GetCollection<LearningPath>(nameof(LearningPath));
      _mapper = mapper;
    }

    public async Task<LearningPath> Insert(LearningPath learningPath)
    {
      await _collection.InsertOneAsync(learningPath);
      return learningPath;
    }

    public async Task<LearningPath> LoadById(Guid Id)
    {
      var ret = await _collection.FindAsync(x => x.Id == Id);
      return await ret.FirstOrDefaultAsync();
    }

    public IQueryResult<LearningPathDTO> GetAllPaginated(string filter, RequestAllOptionsDTO optionsDTO)
    {
      var result = _collection.AsQueryable();

      if (!string.IsNullOrEmpty(filter))
        result = result.Where(x => x.Name.ToLower().Contains(filter.ToLower()));

      var mapped = _mapper.Map<IEnumerable<LearningPathDTO>>(result);
      return AutoMapperQueryble.Paginate(mapped, optionsDTO);
    }
  }
}
