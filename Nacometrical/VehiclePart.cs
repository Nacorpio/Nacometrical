namespace Nacometrical
{
  public interface IVehiclePart : IBreakable
  {
    byte Id { get; }
  }

  public class VehiclePart : IVehiclePart
  {
    public VehiclePart ( byte id )
    {
      Id = id;
    }

    public byte Id { get; }

    public bool IsBroken { get; private set; }

    public void Break ( )
    {
      if ( IsBroken )
      {
        return;
      }

      IsBroken = true;
    }

    public void Fix ( )
    {
      if ( !IsBroken )
      {
        return;
      }

      IsBroken = false;
    }
  }
}