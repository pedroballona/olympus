using System;
using System.Diagnostics.CodeAnalysis;
using Totvs.Olympus.Domain.Entities;
using Xunit;

namespace Totvs.Olympus.Domain.UnitTests.Entities
{
  public class EntityTest
  {
    [Fact]
    public void Validate_Equality_Operator_Is_Equal_Null_Objects()
    {
      //Arrange      
      var contreteEntityA = new ConcreteEntity("SOMEVALUE_1");
      ConcreteEntity contreteEntityB = null;
      ConcreteEntity contreteEntityC = null;

      //Act
      var result1 = (contreteEntityA == contreteEntityB);
      var result2 = (contreteEntityB == contreteEntityC);
      var result3 = (contreteEntityA == contreteEntityC);
      var result4 = (contreteEntityB == contreteEntityA);

      //Assert
      Assert.False(result1);
      Assert.True(result2);
      Assert.False(result3);
      Assert.False(result4);
    }

    [Fact]
    public void Validate_Equal_Method()
    {
      //Arrange
      var guid = new Guid("123e4567-e89b-12d3-a456-426655440000");
      var contreteEntityA = new ConcreteEntity(guid, "SOMEVALUE_2");
      var contreteEntityB = new ConcreteEntity(guid, "SOMEVALUE_2");
      var referenceContreteEntityA = contreteEntityA;

      //Act
      var result1 = contreteEntityA.Equals(null);
      var result2 = contreteEntityA.Equals(contreteEntityB);
      var result3 = contreteEntityA.Equals(referenceContreteEntityA);

      //Assert
      Assert.False(result1);
      Assert.True(result2);
      Assert.True(result3);
    }

    [Fact]
    public void Validate_Equality_Operator_Is_Equal()
    {
      //Arrange
      var guid = new Guid("123e4567-e89b-12d3-a456-426655440000");
      var contreteEntityA = new ConcreteEntity(guid, "SOMEVALUE");
      var contreteEntityB = new ConcreteEntity(guid, "SOMEVALUE");

      var contreteEntityC = new ConcreteEntity(guid, "SOMEVALUE_C");
      var contreteEntityD = new ConcreteEntity(guid, "SOMEVALUE_D");

      //Act
      var result1 = (contreteEntityA == contreteEntityB);
      var result2 = (contreteEntityC == contreteEntityD);

      //Assert
      Assert.True(result1);
      Assert.True(result2);
    }

    [Fact]
    public void Validate_Equality_Operator_Is_Not_Equal()
    {
      //Arrange      
      var contreteEntityA = new ConcreteEntity("SOMEVALUE");
      var contreteEntityB = new ConcreteEntity("SOMEVALUE");

      var contreteEntityC = new ConcreteEntity("SOMEVALUE_C");
      var contreteEntityD = new ConcreteEntity("SOMEVALUE_D");

      //Act
      var result1 = (contreteEntityA == contreteEntityB);
      var result2 = (contreteEntityC == contreteEntityD);

      //Assert
      Assert.False(result1);
      Assert.False(result2);
    }

    [Fact]
    public void Validate_Inequality_Operator_Is_Equal()
    {
      //Arrange
      var guid = new Guid("123e4567-e89b-12d3-a456-426655440000");
      var contreteEntityA = new ConcreteEntity(guid, "SOMEVALUE");
      var contreteEntityB = new ConcreteEntity(guid, "SOMEVALUE");

      var contreteEntityC = new ConcreteEntity(guid, "SOMEVALUE_C");
      var contreteEntityD = new ConcreteEntity(guid, "SOMEVALUE_D");

      //Act
      var result1 = (contreteEntityA != contreteEntityB);
      var result2 = (contreteEntityC != contreteEntityD);

      //Assert
      Assert.False(result1);
      Assert.False(result2);
    }

    [Fact]
    public void Validate_Inequality_Operator_Is_Differents()
    {
      //Arrange      
      var contreteEntityA = new ConcreteEntity("SOMEVALUE");
      var contreteEntityB = new ConcreteEntity("SOMEVALUE");

      var contreteEntityC = new ConcreteEntity("SOMEVALUE_C");
      var contreteEntityD = new ConcreteEntity("SOMEVALUE_D");

      //Act
      var result1 = (contreteEntityA != contreteEntityB);
      var result2 = (contreteEntityC != contreteEntityD);

      //Assert
      Assert.True(result1);
      Assert.True(result2);
    }

    [Fact]
    public void Validate_Hashcode_generator()
    {
      //Arrange
      var guid = new Guid("123e4567-e89b-12d3-a456-426655440000");
      var contreteEntity = new ConcreteEntity(guid, "SOMEVALUE");
      var hash = (contreteEntity.GetType().GetHashCode() * 907) + contreteEntity.Id.GetHashCode();

      //Act
      var result = contreteEntity.GetHashCode();

      //Assert
      Assert.Equal(hash, result);
    }

    [Fact]
    public void Validate_result_to_string_conversion()
    {
      //Arrange
      var guid = new Guid("123e4567-e89b-12d3-a456-426655440000");
      var contreteEntity = new ConcreteEntity(guid, "SOMEVALUE");

      //Act
      var result = contreteEntity.ToString();

      //Assert
      Assert.Equal("ConcreteEntity [Id=123e4567-e89b-12d3-a456-426655440000]", result);
    }
  }

  [ExcludeFromCodeCoverage]
  public class ConcreteEntity : Entity
  {
    public string SomeProperty { get; set; }
    public ConcreteEntity(Guid id, string someProperty) 
      : base(id)
    {
      SomeProperty = someProperty;
    }

    public ConcreteEntity(string someProperty) 
      : base()
    {
      SomeProperty = someProperty;
    }    
  }
}

