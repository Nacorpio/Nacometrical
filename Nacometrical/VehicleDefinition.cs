namespace Nacometrical
{
  public partial class VehicleDefinition
  {
    public readonly struct VehicleLightInfo
    {
      public string Name { get; init; }
      public bool IsBroken { get; init; }

      public VehicleLightState State { get; init; }
      public VehicleLightType Type { get; init; }
    }

    public readonly struct VehicleDoorInfo
    {
      public string Name { get; init; }
      public string WindowName { get; init; }

      public bool IsBroken { get; init; }
      public bool IsOpen { get; init; }
      public bool IsLocked { get; init; }
    }

    public readonly struct VehicleWindowInfo
    {
      public string Name { get; init; }

      public bool IsBroken { get; init; }
      public bool IsOpen { get; init; }
    }
  }

  public partial class VehicleDefinition : DefinitionBase
  {
    public VehicleDefinition ( string name ) : base ( name )
    { }

    public VehicleDoorInfo[] Doors
    {
      get => _properties.GetValueOrDefault <VehicleDoorInfo[]> ( "doors" );
      set => _properties [ "doors" ] = value;
    }

    public VehicleWindowInfo[] Windows
    {
      get => Properties.GetValueOrDefault <VehicleWindowInfo[]> ( "windows" );
      set => _properties [ "windows" ] = value;
    }

    public VehicleLightInfo[] Lights
    {
      get => Properties.GetValueOrDefault <VehicleLightInfo[]> ( "lights" );
      set => _properties [ "lights" ] = value;
    }

    public string ModelName
    {
      get => _properties.GetValueOrDefault <string> ( "model_name" );
      set => _properties [ "model_name" ] = value;
    }

    public string Manufacturer
    {
      get => _properties.GetValueOrDefault <string> ( "manufacturer" );
      set => _properties [ "manufacturer" ] = value;
    }

    public int DriverSeatCount
    {
      get => _properties.GetValueOrDefault <int> ( "passenger_seat_count" );
      set => _properties [ "passenger_seat_count" ] = value;
    }

    public int PassengerSeatCount
    {
      get => _properties.GetValueOrDefault <int> ( "passenger_seat_count" );
      set => _properties [ "passenger_seat_count" ] = value;
    }
  }
}