namespace Nacometrical
{
  public class Property <T> : Property
  {
    public bool IsDefault => GetValue ( )
     .Equals ( default ( T ) );

    public Property ( string name, T value = default ) : base ( name, value )
    { }

    public new T GetValue ( )
    {
      return (T) base.GetValue ( );
    }

    public void SetValue ( T value )
    {
      base.SetValue ( value );
    }
  }

  public class Property
  {
    private object _value;

    public string Name { get; }
    public bool IsNull => _value == null;

    public Property ( string name, object value = null )
    {
      Name = name;
      _value = value;
    }

    public object GetValue ( )
    {
      return _value;
    }

    public void SetValue ( object value )
    {
      _value = value;
    }
  }
}