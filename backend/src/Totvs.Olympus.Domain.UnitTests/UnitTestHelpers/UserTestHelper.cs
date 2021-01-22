using Totvs.Olympus.Domain.Entities;

namespace Totvs.Olympus.Domain.UnitTests.UnitTestHelpers
{
  public static class UserTestHelper
  {
    public static User GetInvalidUser()
    {
      return new User(string.Empty, string.Empty, null);
    }

    public static User GetValidUser()
    {
      return new User("Arlindo Cruz", "cruz.credo@totvs.com.br", null);
    }

  }
}
