namespace Nacometrical
{
  public class Creature : Entity
  {
    public Creature ( ulong id ) : base ( id )
    { }

    public Vehicle CurrentVehicle { get; private set; }

    public void EnterVehicle ( Vehicle vehicle )
    {
      if ( CurrentVehicle != null )
      {
        return;
      }

      var seats = vehicle.Seats;

      if ( !seats.HasFreeSeat ( ) )
      {
        return;
      }

      var seat = seats.FindFreeSeat ( );

      seat.SetOccupant ( this );
      CurrentVehicle = vehicle;
    }

    public void LeaveVehicle ( )
    {
      var seat = CurrentVehicle?.Seats.FindUsedSeat ( this );

      if ( seat == null )
      {
        return;
      }

      seat.SetOccupant ( null );
      CurrentVehicle = null;
    }
  }
}