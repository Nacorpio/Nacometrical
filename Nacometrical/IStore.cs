using System;
using System.Collections.Generic;

namespace Nacometrical
{
  public interface IStore
  {
    int Count { get; }
  }

  public interface IStore <T> : IStore
  {
    void Add ( T item );
    void AddRange ( IEnumerable <T> items );

    bool Remove ( T item );
    bool Contains ( T item );

    bool ContainsMany ( IEnumerable <T> items );
    int RemoveMany ( IEnumerable <T> items );

    IEnumerable <T> FindMany ( Predicate <T> predicate );
    T Find ( Predicate <T> predicate );
  }
}