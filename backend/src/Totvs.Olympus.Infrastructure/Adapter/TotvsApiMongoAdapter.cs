using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using Totvs.Olympus.CrossCutting.DefaultContract;

namespace Totvs.Olympus.Infrastructure.Adapter
{
  public static class TotvsApiMongoAdapter
  {
    private const string MatchSortingFieldsFromTOTVSApi = "(?<signal>[\\-, \\+])?\\s*(?<name>\\w+)\\s*,?\\s*";

    public static PaginationOptions<TDocument> AdaptOptionsToMongo<TDocument>(RequestAllOptionsDTO request)
    {
      if (request == null)
        return null;
      return new PaginationOptions<TDocument>()
      {
        Page = request.Page,
        PageSize = request.PageSize,
        Sorting = TransformToLambdas<TDocument>(request.Order)
      };
    }

    private static IList<(Expression<Func<TDocument, object>> Selector, bool Ascending)> TransformToLambdas<TDocument>(string order)
    {
      if (order == null)
        return null;
      var lambdas = new List<(Expression<Func<TDocument, object>> Selector, bool Ascending)>();
      foreach (Match match in Regex.Matches(order, MatchSortingFieldsFromTOTVSApi))
      {
        string signal = match.Groups["signal"].Value?.Trim();
        string name = match.Groups["name"].Value?.Trim();
        var isAscending = string.IsNullOrEmpty(signal) || signal == "+";
        var property = typeof(TDocument).GetProperties().FirstOrDefault(p => p.Name.ToLower() == name.ToLower());
        if (property != default)
        {
          var parameter = Expression.Parameter(typeof(TDocument), "document");
          var body = Expression.Convert(Expression.Property(parameter, property), typeof(object));
          var lambda = Expression.Lambda<Func<TDocument, object>>(body, new ParameterExpression[] { parameter });
          lambdas.Add((lambda, isAscending));
        }
      }
      return lambdas;
    }
  }
}
