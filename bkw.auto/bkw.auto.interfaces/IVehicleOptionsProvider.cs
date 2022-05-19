

namespace bkw.auto.interfaces
{
    public interface IVehicleOptionsProvider
    {
        IEnumerable<bkw.auto.interfaces.IVehicleOption> GetVehicleOptions(VehicleKind kind);
    }
}
