using System;

namespace Nacometrical
{
  public interface IObservableValue
  {
    event EventHandler Changed;
  }

  public interface IObservableValue <T> : IObservableValue
  {
    T Get ( );
    void Set ( T value );
  }
}