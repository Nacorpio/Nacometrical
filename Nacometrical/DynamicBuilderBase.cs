namespace Nacometrical
{
  public abstract class DynamicBuilderBase <This , TOut> : BuilderBase <TOut> , IDynamicBuilder <TOut>
    where This : DynamicBuilderBase <This , TOut>
  {
    private readonly PropertyBag _properties = new ( );

    public IImmutablePropertyBag Properties => _properties;

    public This Set <TValue> ( string propertyName , TValue value )
    {
      _properties.SetValue ( propertyName , value );
      return (This) this;
    }
  }

  public abstract class DynamicBuilderBase <This , TOut , TIn> : BuilderBase <TOut , TIn> , IDynamicBuilder <TOut , TIn>
    where This : DynamicBuilderBase <This , TOut , TIn>
  {
    private readonly PropertyBag _properties = new ( );

    public IImmutablePropertyBag Properties => _properties;

    public This Set <TValue> ( string propertyName , TValue value )
    {
      _properties.SetValue ( propertyName , value );
      return (This) this;
    }
  }
}