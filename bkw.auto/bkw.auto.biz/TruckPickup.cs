using bkw.auto.interfaces;


namespace bkw.auto.biz
{
    public class TruckPickup : VehicleBase
    {
        private TruckPickup(string name, IVehicleOptionsProvider vehicleOpts) : base(VehicleKind.TruckPickup, name, "Pickup Truck")
        {
            var truckOptions = vehicleOpts.GetVehicleOptions(this._kind);

            System.Diagnostics.Debug.WriteLine($"{truckOptions.Count()} pickup truck options");


            this.DriveTrain = new bkw.auto.biz.drivetrains.HeavyDriveTrain();
            this.DriveTrain.LoadOptions(truckOptions.Where(opt => opt is drivetrains.DriveTrainOption));

            this.Interior = new bkw.auto.biz.interior.StandardInterior();
            this.Interior.LoadOptions(truckOptions.Where(opt => opt is interior.InteriorOption));

            this.Exterior = new bkw.auto.biz.exterior.FactoryExterior();
            this.Exterior.LoadOptions(truckOptions.Where((opt) => opt is exterior.ExteriorOption));

        }

        public override IVehicleOptionModel DriveTrain { get; }

        public override IVehicleOptionModel Interior { get; }

        public override IVehicleOptionModel Exterior { get; }

        public static IVehicle BuildCar(string name, IVehicleOptionsProvider vehicleOpts)
        {
            return new TruckPickup(name, vehicleOpts);
        }
    }

}
