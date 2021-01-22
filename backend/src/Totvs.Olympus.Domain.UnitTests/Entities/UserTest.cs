using FluentValidation.TestHelper;
using Totvs.Olympus.Domain.Validations;
using Xunit;
using static Totvs.Olympus.Domain.UnitTests.UnitTestHelpers.UserTestHelper;
using static Totvs.Olympus.Domain.UnitTests.UnitTestHelpers.CourseTestHelper;
using static Totvs.Olympus.Domain.UnitTests.UnitTestHelpers.LearningPathsTestHelper;

namespace Totvs.Olympus.Domain.UnitTests.Entities
{
  public class UserTest
  {
    private readonly UserValidator _validator;

    public UserTest()
    {
      _validator = new UserValidator();
    }

    [Fact]
    public void GivenInvalidInputs_WhenCreatingAnUser_ThenThrowNotifications()
    {
      var user = GetInvalidUser();

      var result = _validator.TestValidate(user);

      result.ShouldHaveValidationErrorFor(i => i.Name);
      result.ShouldHaveValidationErrorFor(i => i.Email);

      Assert.True(user.Invalid);
      Assert.False(user.Valid);
    }

    [Fact]
    public void GivenValidInputs_WhenCreatingAnUser_ThenDontThrowNotifications()
    {
      var user = GetValidUser();

      var result = _validator.TestValidate(user);

      result.ShouldNotHaveValidationErrorFor(i => i.Name);
      result.ShouldNotHaveValidationErrorFor(i => i.Email);

      Assert.False(user.Invalid);
      Assert.True(user.Valid);
    }

    [Fact]
    public void GivenAddNewCourse_WhenAddingANewCourseToUser_ThenAddCourse()
    {
      var user = GetValidUser();
      var newCourse = GetValidCourse();

      user.AddNewCourse(newCourse);

      Assert.Contains(newCourse, user.Courses);
    }

    [Fact]
    public void GivenAddNewLearningPath_WhenAddingANewLearningPathToUser_ThenAddLearningPath()
    {
      var user = GetValidUser();
      var newLearningPath = GetValidLearningPath();

      user.AddNewLearningPath(newLearningPath);

      Assert.Contains(newLearningPath, user.LearningPaths);
    }
  }
}
