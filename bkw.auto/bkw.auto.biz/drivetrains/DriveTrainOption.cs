using bkw.auto.interfaces;

namespace bkw.auto.biz.drivetrains
{
    public class DriveTrainOption:interfaces.IVehicleOption
    {
        public DriveTrainOption()
        {
            CompatibileKinds |= VehicleKind.EconomyCar | VehicleKind.SportsCar | VehicleKind.TruckPickup | VehicleKind.TruckCommercial;
            Brand = "";
            Name = "";
            Description = "";
        }
        public VehicleKind CompatibileKinds { get; set; }

        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Quantity { get; set; }

        public decimal Cost()
        {
            //do lookup into API, to see part costs based on Brand?
            //then multiply by QTY
            //throw new NotImplementedException();
            return 0;
        }

        public override string ToString()
        {
            return $"{Name} {Description} from {Brand}";
        }
    }
}
