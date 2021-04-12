using System;

namespace Nacometrical
{
  public abstract class DynamicVehiclePartBuilder <This , TOut> : DynamicBuilderBase <This , TOut , byte>
    where This : DynamicVehiclePartBuilder <This , TOut>
    where TOut : VehiclePart
  {
    public string CommonName
    {
      get => _properties.GetValueOrDefault ( "common_name" , string.Empty );
      set => Set ( "common_name" , value );
    }

    public string[] Aliases
    {
      get => Properties.GetValueOrDefault ( "aliases" , new string[] { } );
      set => Set ( "aliases" , value );
    }

    public bool IsBroken
    {
      get => _properties.GetValueOrDefault <bool> ( "is_broken" );
      set => Set ( "is_broken" , value );
    }

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
      var part = Activator.CreateInstance ( typeof ( TOut ) , id ) as TOut;

      if ( IsBroken )
      {
        part?.Break ( );
      }

      return part;
    }
  }
}