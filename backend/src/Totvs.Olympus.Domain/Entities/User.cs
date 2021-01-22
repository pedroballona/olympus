using System;
using System.Collections.Generic;
using Totvs.Olympus.Domain.Validations;

namespace Totvs.Olympus.Domain.Entities
{
  public class User : Entity
  {
    public string Name { get; private set; }
    public string Email { get; private set; }
    public Uri Image { get; private set; }
    public IList<Guid> Courses { get; private set; }
    public IList<Guid> LearningPaths { get; private set; }

    public User(string name, 
                string email,
                Uri image = null)
    {
      Name = name;
      Email = email;
      Image = image;
      Courses = new List<Guid>();
      LearningPaths = new List<Guid>();
      Validate();
    }

    public void AddNewCourse(Guid newCourseId)
    {
      Courses.Add(newCourseId);
    }

    public void AddNewLearningPath(Guid newLearningPathId)
    {
      LearningPaths.Add(newLearningPathId);
    }

    public void Validate()
    {
      Validate(this, new UserValidator());
    }
  }
}
