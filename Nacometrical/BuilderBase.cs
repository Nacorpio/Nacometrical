namespace Nacometrical
{
  public abstract class BuilderBase <TOut> : IBuilder <TOut>
  {
    public abstract TOut Build ( );
    public virtual object Build ( object @in ) => Build ( );

    object IBuilder.Build ( ) => Build ( );
  }

  public abstract class BuilderBase <TOut , In> : IBuilder <TOut , In>
  {
    public abstract TOut Build ( In id );

    public virtual object Build ( )
    {
      return Build ( default );
    }

    object IBuilder.Build ( object @in )
    {
      return Build ( (In) @in );
    }
  }
}