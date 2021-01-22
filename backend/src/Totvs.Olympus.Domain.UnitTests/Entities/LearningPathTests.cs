using FluentValidation.TestHelper;
using Totvs.Olympus.Domain.Validations;
using Xunit;
using static Totvs.Olympus.Domain.UnitTests.UnitTestHelpers.LearningPathsTestHelper;

namespace Totvs.Olympus.Domain.UnitTests.Entities
{
  public class LearningPathTests
  {
    private readonly LearningPathValidator _validator;

    public LearningPathTests()
    {
      _validator = new LearningPathValidator();
    }

    [Fact]
    public void GivenInvalidInputs_WhenCreatingAnLearningPath_ThenThrowNotifications()
    {
      var lp = GetInvalidLearningPath();

      var result = _validator.TestValidate(lp);

      result.ShouldHaveValidationErrorFor(i => i.Name);
      result.ShouldHaveValidationErrorFor(i => i.Description);
      result.ShouldHaveValidationErrorFor(i => i.Courses);
      result.ShouldHaveValidationErrorFor(i => i.EmployeeRoles);

      Assert.True(lp.Invalid);
      Assert.False(lp.Valid);
    }

    [Fact]
    public void GivenValidInputs_WhenCreatingAnLearningPath_ThenDontThrowNotifications()
    {
      var lp = GetValidLearningPath();

      var result = _validator.TestValidate(lp);

      result.ShouldNotHaveValidationErrorFor(i => i.Name);
      result.ShouldNotHaveValidationErrorFor(i => i.Description);
      result.ShouldNotHaveValidationErrorFor(i => i.Courses);
      result.ShouldNotHaveValidationErrorFor(i => i.EmployeeRoles);

      Assert.False(lp.Invalid);
      Assert.True(lp.Valid);
    }
  }
}
