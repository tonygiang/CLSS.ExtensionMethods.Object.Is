// A part of the C# Language Syntactic Sugar suite.

namespace CLSS
{

  public static partial class ObjectIs
  {
    /// <summary>
    /// Returns whether this is the specified reference type. This method has a
    /// boxing overhead.
    /// </summary>
    /// <typeparam name="R">The reference type to check against.</typeparam>
    /// <param name="source">The object to test type.</param>
    /// <returns>Whether the source is the specified reference type.</returns>
    public static bool Is<R>(this object source) where R : class
    { return source is R; }

    /// <inheritdoc cref="Is{R}(object)"/>
    /// <param name="castedValue">When this method returns, contains the result
    /// of <paramref name="source"/> casted to the specified reference type, if
    /// the type check results in True, or null if type check results in False.
    /// This parameter is passed uninitialized; any value originally supplied in
    /// <paramref name="castedValue"/> will be overwritten.</param>
    public static bool Is<R>(this object source, out R castedValue)
      where R : class
    {
      var castResult = false;
      castedValue = default(R);
      if (source is R r) { castedValue = r; castResult = true; }
      return castResult;
    }
  }
}