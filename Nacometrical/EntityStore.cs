using System;
using System.Collections.Generic;

namespace Nacometrical
{
  public class EntityStore : Store <IEntity>, IEntityStore
  {
    public IEntity this [ ulong id ] => Find ( x => x.Id.Equals ( id ) );

    public IEntity Get ( ulong entityId ) => this [ entityId ];

    public bool Remove ( ulong entityId )
    {
      var entity = Get ( entityId );

      return entity != null && Remove ( entity );
    }

    public bool Contains ( ulong entityId ) => Get ( entityId ) != null;
  }

  public class EntityStore <T> : EntityStore, IEntityStore <T>
    where T : class, IEntity
  {
    public new T this [ ulong id ] => (T) base.Find ( x => x.Id.Equals ( id ) );

    public void Add ( T item ) => base.Add ( item );
    public void AddRange ( IEnumerable <T> items ) => base.AddRange ( items );

    public bool Remove ( T item ) => base.Remove ( item );
    public bool Contains ( T item ) => base.Contains ( item );

    public int RemoveMany ( IEnumerable <T> items ) => base.RemoveMany ( items );
    public bool ContainsMany ( IEnumerable <T> items ) => base.ContainsMany ( items );

    public T Find ( Predicate <T> predicate )
      => (T) base.Find ( x => predicate ( (T) x ) );

    public IEnumerable <T> FindMany ( Predicate <T> predicate )
      => (IEnumerable <T>) base.FindMany ( x => predicate ( (T) x ) );

    public new T Get ( ulong entityId ) 
      => TryGetValue ( entityId, out var entity ) ? entity : null;

    public bool TryGetValue ( ulong entityId, out T result )
    {
      var entity = Get ( entityId );

      if ( entity != null )
      {
        result = entity;

        return true;
      }

      result = (T) (IEntity) Entity.Null;

      return false;
    }
  }
}