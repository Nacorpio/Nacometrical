namespace Nacometrical
{
  public partial class VehicleDoor : VehiclePart , IOpenable
  {
    public VehicleWindow AttachedWindow { get; private set; }

    public bool IsOpen { get; private set; }
    public bool IsLocked { get; private set; }

    public bool IsClosed => !IsOpen;
    public bool IsUnlocked => !IsLocked;

    public bool HasAttachedWindow => AttachedWindow != null;

    public VehicleDoor ( byte id ) : base ( id )
    { }

    public void FixWindow ( ) => AttachedWindow?.Break ( );
    public void BreakWindow ( ) => AttachedWindow?.Break ( );

    internal void SetAttachedWindow ( VehicleWindow window )
    {
      AttachedWindow = window;
    }

    public void Open ( )
    {
      if ( IsOpen || IsLocked )
      {
        return;
      }

      IsOpen = true;
    }

    public void Close ( )
    {
      if ( IsClosed )
      {
        return;
      }

      IsOpen = false;
    }

    public void Lock ( )
    {
      if ( IsLocked )
      {
        return;
      }

      IsLocked = true;
    }

    public void Unlock ( )
    {
      if ( !IsLocked )
      {
        return;
      }

      IsLocked = false;
    }
  }

  public partial class VehicleDoor
  {
    public bool TryUnlockAndOpen ( ) =>
      TryUnlock ( ) &&
      TryOpen ( );

    public bool TryCloseAndLock ( ) =>
      TryClose ( ) &&
      TryLock ( );

    public bool TryOpen ( )
    {
      if ( IsOpen ) return false;

      Open ( );
      return true;
    }

    public bool TryClose ( )
    {
      if ( IsClosed ) return false;

      Close ( );
      return false;
    }

    public bool TryLock ( )
    {
      if ( IsLocked ) return false;

      Lock ( );
      return true;
    }

    public bool TryUnlock ( )
    {
      if ( IsUnlocked ) return false;

      Unlock ( );
      return true;
    }
  }
}