﻿namespace Nacometrical
{
  public class Entity : IEntity 
  {
    public static Entity Null => new ( );

    private BaseDefinition _definition;

    public Entity ( ulong id )
    {
      Id = id;
    }

    public Entity ( )
    {
      Id = ulong.MaxValue;
    }

    public ulong Id { get; }
    public bool IsNull => Id == ulong.MaxValue;

    public IDefinition GetDefinition ( ) => _definition;

    public void SetDefinition ( BaseDefinition definition )
    {
      _definition = definition;
      Initialize ( );
    }

    public virtual void Initialize ( )
    { }

    public virtual void Destroy ( )
    { }
  }
}