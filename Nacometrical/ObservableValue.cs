using System;
using System.Collections.Generic;

namespace Nacometrical
{
  public partial class ObservableValue <T> : IObservableValue <T>
  {
    private T _value;

    public event EventHandler Changed;
    
    public ObservableValue ( T value = default )
    {
      _value = value;
    }

    public T Get ( )
    {
      return _value;
    }

    public void Set ( T value )
    {
      _value = value;
      OnChanged ( );
    }

    protected virtual void OnChanged ( )
    {
      Changed?.Invoke ( this, EventArgs.Empty );
    }
  }

  public partial class ObservableValue <T> : IEquatable <ObservableValue <T>>
  {
    public bool Equals ( ObservableValue <T> other ) =>
      !ReferenceEquals ( null, other ) && ( ReferenceEquals
        ( this, other ) || EqualityComparer <T>.Default.Equals ( _value, other._value ) );

    public override bool Equals ( object obj ) =>
      !ReferenceEquals ( null, obj ) && ( ReferenceEquals
        ( this, obj ) || obj.GetType ( ) == GetType ( ) && Equals ( (ObservableValue <T>) obj ) );

    public override int GetHashCode ( ) =>
      EqualityComparer <T>.Default.GetHashCode ( _value );
  }

  public partial class ObservableValue <T> : ICloneable
  {
    public object Clone ( ) => new ObservableValue <T> ( _value );
  }

  public partial class ObservableValue <T>
  {
    public static explicit operator T ( ObservableValue <T> _ ) =>
      _._value;

    public static explicit operator ObservableValue <T> ( T _ ) =>
      new ( _ );

    public static bool operator == ( ObservableValue <T> left, ObservableValue <T> right ) =>
      Equals ( left, right );

    public static bool operator != ( ObservableValue <T> left, ObservableValue <T> right ) =>
      !Equals ( left, right );
  }
}