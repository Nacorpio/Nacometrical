namespace Nacometrical
{
  public class VehicleWindowBuilder : VehiclePartBuilder <VehicleWindowBuilder, VehicleWindow>
  {
    private bool _isOpened;

    public VehicleWindowBuilder SetOpened ( bool value )
    {
      _isOpened = value;
      return this;
    }

    public override VehicleWindow Build ( byte id )
    {
      var window = base.Build ( id );

      if ( _isOpened )
      {
        window.Open ( );
      }

      return window;
    }
  }
}