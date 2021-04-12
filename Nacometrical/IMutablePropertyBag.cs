using System.Collections.Generic;

namespace Nacometrical
{
  public interface IMutablePropertyBag : IImmutablePropertyBag
  {
    new object this [ string propertyName ] { get; set; }

    void SetValue <T> ( string propertyName, T value );
    void SetValues ( IReadOnlyDictionary <string, object> values );
  }
}