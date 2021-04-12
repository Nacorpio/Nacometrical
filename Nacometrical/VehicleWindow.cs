namespace Nacometrical
{
  public class VehicleWindow : VehiclePart, IOpenable
  {
    public bool IsClosed { get; private set; }
    public bool IsOpen => !IsClosed;

    public VehicleWindow ( byte id ) : base (id)
    {
      Id = id;
    }

    public void Open ( )
    {
      if ( IsOpen )
      {
        return;
      }

      IsClosed = false;
    }

    public void Close ( )
    {
      if ( IsClosed )
      {
        return;
      }

      IsClosed = true;
    }
  }
}