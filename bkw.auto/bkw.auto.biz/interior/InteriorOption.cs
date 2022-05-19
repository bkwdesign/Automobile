using bkw.auto.interfaces;

namespace bkw.auto.biz.interior
{
    public class InteriorOption : bkw.auto.interfaces.IVehicleOption
    {
        public InteriorOption()
        {
            CompatibileKinds |= VehicleKind.EconomyCar | VehicleKind.SportsCar | VehicleKind.TruckPickup | VehicleKind.TruckCommercial;
            Brand = "";
            Name = "";
            Description = "";
        }

        /// <summary>
        /// by default this bit-wise enum is set to all options, but can be modified after instantiation
        /// </summary>
        public VehicleKind CompatibileKinds { get; set; }
    

        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Quantity { get; set; }

        public decimal Cost()
        {
            //do lookup into API, to see part costss based on Brand?
            //then multiply by QTY
            //throw new NotImplementedException();
            return 0;
        }

        
    }
}
