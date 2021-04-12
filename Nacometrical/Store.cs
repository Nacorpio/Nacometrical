using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nacometrical
{
  public class Store <T> : IStore <T>, IEnumerable <T>
  {
    private readonly List <T> _items = new ( );

    public int Count => _items.Count;

    public void Add ( T item )
    {
      if ( Contains ( item ) )
      {
        return;
      }

      _items.Add ( item );
    }

    public void AddRange ( IEnumerable <T> items )
    {
      foreach ( var item in items )
      {
        Add ( item );
      }
    }

    public bool Remove ( T item )
    {
      return _items.Contains ( item ) && _items.Remove ( item );
    }

    public int RemoveMany ( IEnumerable <T> items )
    {
      return items.Count ( Remove );
    }

    public bool Contains ( T item )
    {
      return _items.Contains ( item );
    }

    public bool ContainsMany ( IEnumerable <T> items )
    {
      return _items.All ( Contains );
    }

    public T Find ( Predicate <T> predicate )
    {
      return _items.Find ( predicate );
    }

    public IEnumerable <T> FindMany ( Predicate <T> predicate )
    {
      return _items.Where ( x => predicate ( x ) );
    }

    public IEnumerator <T> GetEnumerator ( )
    {
      return _items.GetEnumerator ( );
    }

    IEnumerator IEnumerable.GetEnumerator ( )
    {
      return GetEnumerator ( );
    }
  }
}