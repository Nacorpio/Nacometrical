namespace Nacometrical
{
  public interface IOpenable
  {
    bool IsOpen { get; }
    bool IsClosed { get; }

    void Open ( );
    void Close ( );
  }
}