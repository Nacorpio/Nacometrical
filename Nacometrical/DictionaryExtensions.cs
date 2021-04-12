using System.Collections.Generic;

namespace Nacometrical
{
  public static class DictionaryExtensions
  {
    public static bool TryGetKey <TKey, TValue>
      ( this IDictionary <TKey, TValue> _, TValue value, out TKey key )
    {
      foreach ( var (k, v) in _ )
      {
        if ( !v.Equals ( value ) )
        {
          continue;
        }

        key = k;
        return true;
      }

      key = default;
      return false;
    }

    public static bool ContainsValue <TKey, TValue> ( this IDictionary <TKey, TValue> _, TValue value )
    {
      return _.Values.Contains ( value );
    }

    public static bool Remove <TKey, TValue> ( this IDictionary <TKey, TValue> _, TValue value ) =>
      _.ContainsValue ( value ) &&
      _.TryGetKey ( value, out var key ) &&
      _.Remove ( key );
  }
}