using bkw.auto.interfaces;


namespace bkw.auto.biz
{
    public class EconomyCar : VehicleBase
    {
        private EconomyCar(string name, IVehicleOptionsProvider vehicleOpts):base(VehicleKind.EconomyCar,name,"Economy Car")
        {
            var economyCarOptions = vehicleOpts.GetVehicleOptions(this._kind);

            System.Diagnostics.Debug.WriteLine($"{economyCarOptions.Count()} econ car options");

            this.DriveTrain = new bkw.auto.biz.drivetrains.StandardDriveTrain();
            this.DriveTrain.LoadOptions(economyCarOptions.Where(opt => opt is drivetrains.DriveTrainOption));

            this.Interior = new bkw.auto.biz.interior.StandardInterior();
            this.Interior.LoadOptions(economyCarOptions.Where(opt => opt is interior.InteriorOption));

            this.Exterior = new bkw.auto.biz.exterior.FactoryExterior();
            this.Exterior.LoadOptions(economyCarOptions.Where((opt) => opt is exterior.ExteriorOption));

        }
        public override IVehicleOptionModel DriveTrain { get; }

        public override IVehicleOptionModel Interior { get; }

        public override IVehicleOptionModel Exterior { get; }

        public static IVehicle BuildCar(string name, IVehicleOptionsProvider vehicleOpts)
        {
            return new EconomyCar(name, vehicleOpts);
        }
    }
}
