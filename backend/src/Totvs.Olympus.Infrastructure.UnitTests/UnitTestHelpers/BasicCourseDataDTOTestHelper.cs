using System;
using System.Collections.Generic;
using System.Text;
using Totvs.Olympus.CrossCutting.ExternalServices.ResponsesDTO;

namespace Totvs.Olympus.Infrastructure.UnitTests.UnitTestHelpers
{
  public static class BasicCourseDataDTOTestHelper
  {
    public static BasicCourseDataDTO GetBasicCourseDataDTO()
    {
      return new BasicCourseDataDTO()
      {
        Nome = ".Net e MongoDB parte 1: Primeiros passos para usar esse famoso banco NoSQL",
        Slug = "dotnet-mongodb",
        TempoEstimado = 16
      };
    } 
  }
}
