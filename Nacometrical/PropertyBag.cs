using System.Collections.Generic;
using System.Linq;

namespace Nacometrical
{
  public class PropertyBag : IMutablePropertyBag
  {
    private readonly Dictionary <string, Property> _properties;

    public PropertyBag ( )
    {
      _properties = new Dictionary <string, Property> ( );
    }

    public object this [ string propertyName ]
    {
      get => _properties [ propertyName ]?.GetValue ( );
      set => _SetValue ( propertyName, value );
    }

    public bool Contains ( string propertyName )
    {
      return _properties.ContainsKey ( propertyName );
    }

    public bool ContainsMany ( IEnumerable <string> properties )
    {
      return _properties.Keys.All ( Contains );
    }

    public void SetValues ( IReadOnlyDictionary <string, object> values )
    {
      foreach ( var (name, value) in values )
      {
        _SetValue ( name, value );
      }
    }

    public void SetValue <T> ( string propertyName, T value )
    {
      _SetValue ( propertyName, value );
    }

    public T GetValue <T> ( string propertyName )
    {
      if ( !Contains ( propertyName ) )
      {
        return default;
      }

      return (T) _properties [ propertyName ].GetValue ( );
    }

    public T GetValueOrDefault <T> ( string propertyName, T @default = default )
    {
      return GetValue <T> ( propertyName ) ?? @default;
    }

    public bool TryGetValue ( string propertyName, out object value )
    {
      if ( !_properties.TryGetValue ( propertyName, out var property ) )
      {
        value = null;

        return false;
      }

      value = property.GetValue ( );

      return true;
    }

    private void _SetValue ( string propertyName, object value )
    {
      if ( !Contains ( propertyName ) )
      {
        _properties.Add ( propertyName, new Property ( propertyName, value ) );

        return;
      }

      _properties [ propertyName ].SetValue ( value );
    }
  }
}