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

  public interface IDynamicBuilder : IBuilder
  {
    IImmutablePropertyBag Properties { get; }
  }

  public interface IDynamicBuilder <out T> : IBuilder <T>, IDynamicBuilder
  {
  }

  public interface IDynamicBuilder <out T, in TIn> : IBuilder<T, TIn>, IDynamicBuilder
  {
  }
}