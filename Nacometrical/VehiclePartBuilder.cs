using System;

namespace Nacometrical
{
  public class VehiclePartBuilder<T, TPart> : BuilderBase<TPart, byte>
    where T : VehiclePartBuilder <T, TPart>
    where TPart : VehiclePart
  {
    public string CommonName { get; private set; }
    public string[] Aliases { get; private set; }

    public bool IsBroken { get; private set; }

    public T WithCommonName ( string value )
    {
      CommonName = value;
      return (T) this;
    }

    public T WithAliases ( params string[] values )
    {
      Aliases = values;
      return (T) this;
    }

    public T SetBroken ( bool value )
    {
      IsBroken = value;
      return (T) this;
    }

    public override TPart Build ( byte id )
    {
      var part = Activator.CreateInstance (typeof(TPart), id) as TPart;

      if ( IsBroken )
      {
        part?.Break ( );
      }

      return part;
    }
  }
}