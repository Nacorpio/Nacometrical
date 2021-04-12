namespace Nacometrical
{
  public interface IDefinition : IUnit
  {
    /// <summary>
    /// Gets the name of the <see cref="IDefinition"/>.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    string Name { get; }

    /// <summary>
    /// Gets an immutable bag of properties contained in the <see cref="IDefinition"/>.
    /// </summary>
    /// <value>
    /// The properties.
    /// </value>
    IImmutablePropertyBag Properties { get; }
  }
}