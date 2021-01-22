using AutoMapper;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Totvs.Olympus.CrossCutting.DefaultContract;
using Totvs.Olympus.CrossCutting.DTOs;
using Totvs.Olympus.Domain.Entities;
using Totvs.Olympus.Domain.RepositoryContracts;
using Totvs.Olympus.Infrastructure.Adapter;
using Totvs.Olympus.Infrastructure.Models;

namespace Totvs.Olympus.Infrastructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly IMongoCollection<User> _collection;
    private readonly IMapper _mapper;

    public UserRepository(IOlympusDatabaseSettings settings, 
                          IMapper mapper)
    {
      var client = new MongoClient(settings.ConnectionString);
      var database = client.GetDatabase(settings.DatabaseName);

      _collection = database.GetCollection<User>(nameof(User));
      _mapper = mapper;
    }

    public async Task<UserDTO> GetLoggedUser()
    {
      return _mapper.Map<UserDTO>(await _collection.AsQueryable().FirstOrDefaultAsync());
    }

    public IQueryResult<UserDTO> GetAllUsers(string filter, RequestAllOptionsDTO options)
    {
      var result = _collection.AsQueryable();

      if (!string.IsNullOrEmpty(filter))
        result = result.Where(x => x.Name.ToLower().Contains(filter.ToLower()));


      var mapped = _mapper.Map<IEnumerable<UserDTO>>(result);
      return AutoMapperQueryble.Paginate(mapped, options);

    }

    public async Task<UserDTO> AddNewCourseToUser(Guid id, Guid newCourseId)
    {
      var user = await LoadById(id);
      user.AddNewCourse(newCourseId);

      var filter = Builders<User>.Filter.Eq(u => u.Id, id);
      var update = Builders<User>.Update.Set(u => u.Courses, user.Courses).
                                         Set(u => u.DateUpdated, DateTime.Now);

      await _collection.UpdateOneAsync(filter, update);
      return _mapper.Map<UserDTO>(await LoadById(id));
    }

    public async Task<UserDTO> AddNewLearningPath(Guid id, Guid newLearningPathId)
    {
      var user = await LoadById(id);
      user.AddNewLearningPath(newLearningPathId);

      var filter = Builders<User>.Filter.Eq(u => u.Id, id);
      var update = Builders<User>.Update.Set(u => u.LearningPaths, user.LearningPaths).
                                         Set(u => u.DateUpdated, DateTime.Now);

      await _collection.UpdateOneAsync(filter, update);
      return _mapper.Map<UserDTO>(await LoadById(id));
    }

    public async Task<UserDTO> CreateUser(UserInputDTO inputDTO)
    {
      var newUser = new User(inputDTO.Name, inputDTO.Email);

      if (newUser.Valid)
      {
        await _collection.InsertOneAsync(newUser);
        return _mapper.Map<UserDTO>(newUser);
      }
      return null;
    }

    public async Task DeleteUser(Guid id)
    {
      await _collection.DeleteOneAsync(u => u.Id == id);
      return ;
    }

    public async Task<UserDTO> GetUserById(Guid id)
    {
      return _mapper.Map<UserDTO>(await LoadById(id));
    }

    public async Task<UserDTO> UpdateUser(Guid id, UserInputDTO inputDTO)
    {
      var filter = Builders<User>.Filter.Eq(u => u.Id, id);
      var update = Builders<User>.Update.Set(u => u.Name, inputDTO.Name).
                                         Set(u => u.Email, inputDTO.Email).
                                         Set(u => u.DateUpdated, DateTime.Now);

      await _collection.UpdateOneAsync(filter, update);
      return _mapper.Map<UserDTO>(await LoadById(id));
    }

    public async Task<User> LoadById(Guid Id)
    {
      var ret = await _collection.FindAsync(x => x.Id == Id);
      return await ret.FirstOrDefaultAsync();
    }
  }
}
