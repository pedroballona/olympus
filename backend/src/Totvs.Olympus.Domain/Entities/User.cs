using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Olympus.Domain.Validations;

namespace Totvs.Olympus.Domain.Entities
{
  public class User : Entity
  {
    public string Name { get; private set; }
    public string Email { get; private set; }
    public Uri Image { get; private set; }
    public IList<Course> Courses { get; private set; }
    public IList<LearningPath> LearningPaths { get; private set; }

    public User(string name, 
                string email,
                Uri image)
    {
      Name = name;
      Email = email;
      Image = image;
      Courses = new List<Course>();
      LearningPaths = new List<LearningPath>();
      Validate();
    }

    public void AddNewCourse(Course newCourse)
    {
      Courses.Add(newCourse);
    }

    public void AddNewLearningPath(LearningPath newLearningPath)
    {
      LearningPaths.Add(newLearningPath);
    }

    public void Validate()
    {
      Validate(this, new UserValidator());
    }
  }
}
