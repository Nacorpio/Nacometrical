namespace Nacometrical
{
  public interface IDynamicBuilder : IBuilder
  {
    IImmutablePropertyBag Properties { get; }
  }

  public interface IDynamicBuilder <out TOut , in TIn> : IBuilder <TOut , TIn> , IDynamicBuilder
  { }

  public interface IDynamicBuilder <out TOut> : IBuilder <TOut> , IDynamicBuilder
  { }
}