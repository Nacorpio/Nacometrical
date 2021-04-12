namespace Nacometrical
{
  public interface IBreakable
  {
    bool IsBroken { get; }

    void Break ( );
    void Fix ( );
  }
}