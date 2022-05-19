using bkw.auto.interfaces;


namespace bkw.auto.biz
{
    public class SportsCar : VehicleBase
    {
        private SportsCar(string name, IVehicleOptionsProvider vehicleOpts) : base(VehicleKind.SportsCar, name, "Sports Car")
        {
            var sportsCarOptions = vehicleOpts.GetVehicleOptions(this._kind);

            System.Diagnostics.Debug.WriteLine($"{sportsCarOptions.Count()} sports car options");

            this.DriveTrain = new bkw.auto.biz.drivetrains.StandardDriveTrain();
            this.DriveTrain.LoadOptions(sportsCarOptions.Where(opt => opt is drivetrains.DriveTrainOption));

            this.Interior = new bkw.auto.biz.interior.DeluxeInterior();
            this.Interior.LoadOptions(sportsCarOptions.Where(opt => opt is interior.InteriorOption));

            this.Exterior = new bkw.auto.biz.exterior.AftermarketExterior();
            this.Exterior.LoadOptions(sportsCarOptions.Where((opt) => opt is exterior.ExteriorOption));

        }

        public override IVehicleOptionModel DriveTrain { get; }

        public override IVehicleOptionModel Interior { get; }

        public override IVehicleOptionModel Exterior { get; }

        public static IVehicle BuildCar(string name, IVehicleOptionsProvider vehicleOpts)
        {
            return new SportsCar(name, vehicleOpts);
        }
    }
}
