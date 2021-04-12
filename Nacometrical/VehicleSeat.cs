namespace Nacometrical
{
  public class VehicleSeat
  {
    private Creature _occupant;

    public VehicleSeat ( byte id, VehicleSeatType type )
    {
      Id = id;
      Type = type;
    }

    public byte Id { get; }
    public VehicleSeatType Type { get; }

    public bool IsOccupied => _occupant != null;

    public void SetOccupant ( Creature creature ) => _occupant = creature;
    public Creature GetOccupant ( ) => _occupant;
  }
}