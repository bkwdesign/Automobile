using bkw.auto.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkw.auto.biz.exterior
{
    public class ExteriorOption : bkw.auto.interfaces.IVehicleOption
    {
        public ExteriorOption()
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
            //do lookup into API, to see part costss based on Brand?
            //then multiply by QTY
            //throw new NotImplementedException();
            return 0;
        }

        
    }
}
