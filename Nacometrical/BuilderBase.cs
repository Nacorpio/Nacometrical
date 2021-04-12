namespace Nacometrical
{
  public abstract class BuilderBase <T> : IBuilder <T>
  {
    public abstract T Build ( );

    public virtual object Build ( object @in ) => Build ( );

    object IBuilder.Build ( ) => Build ( );
  }

  public abstract class BuilderBase <T, In> : IBuilder <T, In>
  {
    public abstract T Build ( In id );

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