namespace Nacometrical
{
  public class VehicleSeat : VehiclePart
  {
    private Creature _occupant;

    public VehicleSeat ( byte id , VehicleSeatType type ) : base ( id )
    {
      Type = type;
    }

    public VehicleSeatType Type { get; }

    public bool IsOccupied => _occupant != null;
    public bool IsFree => !IsOccupied;

    public void SetOccupant ( Creature creature ) => _occupant = creature;
    public Creature GetOccupant ( ) => _occupant;

    public void Clear ( ) => SetOccupant ( null );
  }
}