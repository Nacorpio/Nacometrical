namespace Nacometrical
{
  public interface IBuilder
  {
    object Build ( );
    object Build ( object @in );
  }

  public interface IBuilder <out T> : IBuilder
  {
    new T Build ( );
  }

  public interface IBuilder <out T, in In> : IBuilder
  {
    T Build ( In id );
  }
}