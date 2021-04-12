namespace Nacometrical
{
  public class VehicleLightBuilder : VehiclePartBuilder <VehicleLightBuilder , VehicleLight>
  {
    public VehicleLightState State { get; private set; }
    public VehicleLightType Type { get; private set; }

    public VehicleLightBuilder SetState ( VehicleLightState state )
    {
      State = state;
      return this;
    }

    public VehicleLightBuilder SetType ( VehicleLightType type )
    {
      Type = type;
      return this;
    }

    public override VehicleLight Build ( byte id )
    {
      var light = base.Build ( id );

      light.SetState ( State );
      light.SetType ( Type );

      return light;
    }
  }
}