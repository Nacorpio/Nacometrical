using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Nacometrical
{
  public partial class VehiclePartMap <TPart , TPartBuilder>
  {
    /*
     * TODO: Utilize the private class.
     */
    private class VehiclePartMapEntry
    {
      public byte PartId { get; init; }

      public string CommonName { get; init; }
      public string[] Aliases { get; init; }
    }
  }

  public partial class VehiclePartMap <TPart , TPartBuilder>
    : IMutableVehiclePartMap <TPart , TPartBuilder> , IEnumerable <TPart>
    where TPart : VehiclePart
    where TPartBuilder : VehiclePartBuilder <TPartBuilder , TPart> , new ( )
  {
    protected readonly Dictionary <string , byte> PartNameMap = new ( byte.MaxValue );
    protected readonly List <TPart> Entries = new ( byte.MaxValue );

    public TPart this [ byte partId ] => Get ( partId );
    public TPart this [ string partName ] => Get ( partName );

    public TPart Create ( Action <byte , TPartBuilder> buildFunc )
    {
      return _CreatePart ( buildFunc , new TPartBuilder ( ) );
    }

    public IEnumerable <TPart> CreateMany ( int count , Action <byte , TPartBuilder> buildFunc )
    {
      var pb = new TPartBuilder ( );

      for ( var i = 0 ; i < count ; ++i )
      {
        yield return _CreatePart ( buildFunc , pb );
      }
    }

    private TPart _CreatePart ( Action <byte , TPartBuilder> buildFunc , TPartBuilder pb )
    {
      var id = (byte) Entries.Count;
      buildFunc ( id , pb );

      var part = pb.Build ( id );
      Entries.Add ( part );

      var name = pb.CommonName.ToLower ( );

      if ( !string.IsNullOrWhiteSpace ( name ) &&
        !PartNameMap.ContainsKey ( name ) )
      {
        PartNameMap.Add ( name , id );
      }

      return part;
    }


    public IEnumerator <TPart> GetEnumerator ( )
    {
      return Entries.GetEnumerator ( );
    }

    IEnumerator IEnumerable.GetEnumerator ( )
    {
      return GetEnumerator ( );
    }
  }

  public partial class VehiclePartMap <TPart , TPartBuilder>
  {
    public TPart Get ( byte partId ) =>
      Entries.FirstOrDefault ( x => x.Id == partId );

    public TPart Get ( string partName ) =>
      !PartNameMap.TryGetValue ( partName , out var partId ) ? null : Get ( partId );


    public bool Contains ( byte partId ) =>
      PartNameMap.ContainsValue ( partId );

    public bool Contains ( string partName ) =>
      PartNameMap.ContainsKey ( partName );

    public bool Contains ( TPart part ) =>
      Contains ( part.Id );


    public bool Remove ( byte partId ) =>
      Contains ( partId ) && PartNameMap.Remove ( partId );

    public bool Remove ( string partName ) =>
      PartNameMap.TryGetValue ( partName , out var partId ) && Remove ( partId );

    public bool Remove ( TPart part ) =>
      Remove ( part.Id );


    public bool ContainsMany ( IEnumerable <byte> partIds ) =>
      partIds.All ( Contains );

    public bool ContainsMany ( IEnumerable <string> partNames ) =>
      partNames.All ( Contains );

    public bool ContainsMany ( IEnumerable <TPart> parts ) =>
      parts.All ( Contains );


    public int RemoveMany ( IEnumerable <byte> partIds ) =>
      partIds.Count ( Remove );

    public int RemoveMany ( IEnumerable <string> partNames ) =>
      partNames.Count ( Remove );

    public int RemoveMany ( IEnumerable <TPart> parts ) =>
      parts.Count ( Remove );


    public void Clear ( ) =>
      Entries.ForEach ( x => Remove ( x ) );
  }
}