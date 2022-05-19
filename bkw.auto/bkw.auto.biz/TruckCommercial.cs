using bkw.auto.interfaces;

namespace bkw.auto.biz
{
    public class TruckCommercial : VehicleBase
    {
        private TruckCommercial(string name, IVehicleOptionsProvider vehicleOpts) : base(VehicleKind.TruckCommercial, name, "Commerical Van")
        {
            var commercialOptions = vehicleOpts.GetVehicleOptions(this._kind);//some kinds of options may not be appropriate so, filter here

            System.Diagnostics.Debug.WriteLine($"{commercialOptions.Count()} commerial truck options");


            this.DriveTrain = new bkw.auto.biz.drivetrains.HeavyDriveTrain();
            this.DriveTrain.LoadOptions(commercialOptions.Where(opt => opt is drivetrains.DriveTrainOption));

            this.Interior = new bkw.auto.biz.interior.StandardInterior();
            this.Interior.LoadOptions(commercialOptions.Where(opt => opt is interior.InteriorOption));

            this.Exterior = new bkw.auto.biz.exterior.FactoryExterior();
            this.Exterior.LoadOptions(commercialOptions.Where((opt) => opt is exterior.ExteriorOption));

        }

        public override IVehicleOptionModel DriveTrain { get; }

        public override IVehicleOptionModel Interior { get; }

        public override IVehicleOptionModel Exterior { get; }

        public static IVehicle BuildCar(string name, IVehicleOptionsProvider vehicleOpts)
        {
            return new TruckCommercial(name, vehicleOpts);
        }
    }
}
