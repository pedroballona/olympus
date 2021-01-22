using System.Collections.Generic;
using Totvs.Olympus.Domain.ValueObjects;

namespace Totvs.Olympus.Domain.UnitTests.UnitTestHelpers
{
  public static class InstructorsTestHelper
  {
    public static IEnumerable<Instructor> GetValidInstructorsList()
    {
      return new[]
      {
        new Instructor("Tovs"),
        new Instructor("Sílvio"),
        new Instructor("Pedrão"),
        new Instructor("Manu"),
      };
    }
  }
}
