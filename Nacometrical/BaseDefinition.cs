namespace Nacometrical
{
  public abstract class BaseDefinition : IDefinition
  {
    protected readonly PropertyBag _properties = new ( );

    protected BaseDefinition ( string name )
    {
      Name = name;
    }

    public string Name { get; }
    public IImmutablePropertyBag Properties => _properties;
  }
}