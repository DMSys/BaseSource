using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for xFunctions
/// </summary>
public static class xFunctions
{
    /// <summary>
    /// Функция за рязане от начална точка 
    /// </summary>
    /// <param name="startPoint"></param>
    /// <param name="symbol"></param>
    /// <param name="text"></param>
    /// <returns></returns>
  public static string GetIDFromString (int startPoint ,string symbol ,string text)
  {
      return text.Substring(startPoint, text.IndexOf(symbol)).Trim();
  }
  /// <summary>
  /// Функция за рязане за втория елемент в стринга
  /// </summary>
  /// <param name="text"></param>
  /// <returns></returns>
  public static string GetSelectorFromString(int startPoint ,string symbol ,string text)
  {
      int LngtFirststr = text.Substring(startPoint, text.IndexOf(symbol)).Trim().Length;
      return text.Substring(LngtFirststr, text.Length - 1);
  }
  
}