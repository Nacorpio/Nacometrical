namespace Nacometrical
{
  public interface IUnique <out T>
  {
    T Id { get; }
  }
}