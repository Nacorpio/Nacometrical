using System;
using System.Collections.Generic;

namespace Nacometrical
{
  public interface IImmutablePropertyBag : IEnumerable <Property>
  {
    object this [ string propertyName ] { get; }

    bool Contains ( string propertyName );
    bool ContainsMany ( IEnumerable <string> propertyNames );

    T GetValue <T> ( string propertyName );
    T GetValueOrDefault <T> ( string propertyName , T @default = default );

    bool TryGetValue ( string propertyName , out object value );
  }
}