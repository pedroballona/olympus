using System;
using System.Text.RegularExpressions;

namespace Totvs.Olympus.Domain.Validations
{
  public static class ValidationHelper
  {
    private const string EmailValidRegex = "^(?(\")(\".+?(?<!\\\\)\"@)|(([0-9a-z]((\\.(?!\\.))|[-!#\\$%&'\\*\\+/=\\?\\^`\\{\\}\\|~\\w])*)(?<=[0-9a-z])@))(?(\\[)(\\[(\\d{1,3}\\.){3}\\d{1,3}\\])|(([0-9a-z][-\\w]*[0-9a-z]*\\.)+[a-z0-9][\\-a-z0-9]{0,22}[a-z0-9]))$";

    public static bool NotBeNegative(double arg)
    {
      if (arg < 0)
        return false;
      return true;
    }

    public static bool NotBeNegative(decimal arg)
    {
      if (arg < 0)
        return false;
      return true;
    }

    public static bool NotBeNegative(int arg)
    {
      if (arg < 0)
        return false;
      return true;
    }

    public static bool NotBeNegativeOrZero(int arg)
    {
      if (arg <= 0)
        return false;
      return true;
    }

    public static bool NotBeNegativeOrZero(double arg)
    {
      if (arg <= 0)
        return false;
      return true;
    }

    public static bool NotBeNegativeOrZero(decimal arg)
    {
      if (arg <= 0)
        return false;
      return true;
    }

    public static bool NotBeDateDefaultValue(DateTime arg)
    {
      if (arg.CompareTo(DateTime.MinValue) == 0 && arg != null)
        return false;
      return true;
    }

    public static bool BeAValidEmail(string arg)
    {
      return !string.IsNullOrWhiteSpace(arg) && Regex.IsMatch(arg.Trim(), EmailValidRegex);
    }
  }
}
