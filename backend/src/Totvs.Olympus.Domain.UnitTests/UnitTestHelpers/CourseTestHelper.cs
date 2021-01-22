using Totvs.Olympus.Domain.Entities;
using static Totvs.Olympus.Domain.UnitTests.UnitTestHelpers.InstructorsTestHelper;

namespace Totvs.Olympus.Domain.UnitTests.UnitTestHelpers
{
  public static class CourseTestHelper
  {
    public static Course GetValidCourse() 
    {
      return new Course(title: "Curso de testes unitários",
                        note: 9.9,
                        instructors: GetValidInstructorsList());
    }

    public static Course GetInvalidCourse() 
    {
      return new Course(title: string.Empty,
                        note: -1,
                        instructors: null);
    }

  }
}
