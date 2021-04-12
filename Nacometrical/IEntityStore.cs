namespace Nacometrical
{
  public interface IEntityStore <T> : IEntityStore, IStore <T>
    where T : IEntity
  {
    new T this [ ulong id ] { get; }

    new T Get ( ulong entityId );

    bool TryGetValue ( ulong entityId, out T result );
  }

  public interface IEntityStore
  {
    IEntity this [ ulong id ] { get; }

    IEntity Get ( ulong entityId );

    bool Remove ( ulong entityId );
    bool Contains ( ulong entityId );
  }
}