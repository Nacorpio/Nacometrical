namespace Nacometrical
{
  public abstract class DefinitionBase : IDefinition
  {
    protected readonly PropertyBag _properties = new ( );

    protected DefinitionBase ( string name )
    {
      Name = name;
    }

    public string Name { get; }
    public IImmutablePropertyBag Properties => _properties;
  }
}