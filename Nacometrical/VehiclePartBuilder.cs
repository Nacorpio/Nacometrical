using System;

namespace Nacometrical
{
  public class VehiclePartBuilder<This, TOut> : BuilderBase<TOut, byte>
    where This : VehiclePartBuilder <This, TOut>
    where TOut : VehiclePart
  {
    public string CommonName { get; private set; }
    public string[] Aliases { get; private set; }

    public bool IsBroken { get; private set; }

    public This WithCommonName ( string value )
    {
      CommonName = value;
      return (This) this;
    }

    public This WithAliases ( params string[] values )
    {
      Aliases = values;
      return (This) this;
    }

    public This SetBroken ( bool value )
    {
      IsBroken = value;
      return (This) this;
    }

    public override TOut Build ( byte id )
    {
      var part = Activator.CreateInstance (typeof(TOut), id) as TOut;

      if ( IsBroken )
      {
        part?.Break ( );
      }

      return part;
    }
  }
}