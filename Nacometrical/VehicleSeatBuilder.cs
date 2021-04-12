namespace Nacometrical
{
  public class VehicleSeatBuilder : VehiclePartBuilder <VehicleSeatBuilder , VehicleSeat>
  {
    public VehicleSeatType Type { get; private set; }

    public VehicleSeatBuilder WithType ( VehicleSeatType type )
    {
      Type = type;
      return this;
    }

    public override VehicleSeat Build ( byte id )
    {
      var seat = base.Build ( id );
      return seat;
    }
  }
}