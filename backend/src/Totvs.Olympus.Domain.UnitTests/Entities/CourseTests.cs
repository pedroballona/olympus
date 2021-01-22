using FluentValidation.TestHelper;
using Totvs.Olympus.Domain.Validations;
using Xunit;
using static Totvs.Olympus.Domain.UnitTests.UnitTestHelpers.CourseTestHelper;

namespace Totvs.Olympus.Domain.UnitTests.Entities
{
  public class CourseTests
  {
    private readonly CourseValidator _validator;

    public CourseTests()
    {
      _validator = new CourseValidator();
    }

    [Fact]
    public void GivenInvalidInputs_WhenCreatingAnCourse_ThenThrowNotifications()
    {
      var user = GetInvalidCourse();

      var result = _validator.TestValidate(user);

      result.ShouldHaveValidationErrorFor(i => i.Title);
      result.ShouldHaveValidationErrorFor(i => i.Score);

      Assert.True(user.Invalid);
      Assert.False(user.Valid);
    }

    [Fact]
    public void GivenValidInputs_WhenCreatingAnCourse_ThenDontThrowNotifications()
    {
      var course = GetValidCourse();

      var result = _validator.TestValidate(course);

      result.ShouldNotHaveValidationErrorFor(i => i.Title);
      result.ShouldNotHaveValidationErrorFor(i => i.Score);

      Assert.False(course.Invalid);
      Assert.True(course.Valid);
    }
  }
}
