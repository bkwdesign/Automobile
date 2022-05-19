using bkw.auto.interfaces;

namespace bkw.auto.api.Models
{
    public class UserOption : IVehicleOption
    {
        public VehicleKind CompatibileKinds { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Quantity { get; set; }

        public decimal Cost()
        {
            throw new NotImplementedException();
        }
    }
}
