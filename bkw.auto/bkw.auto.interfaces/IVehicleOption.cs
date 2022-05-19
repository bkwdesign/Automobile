namespace bkw.auto.interfaces
{
    public interface IVehicleOption
    {
       VehicleKind CompatibileKinds { get; set; }
       string Brand { get; set; }
       string Name { get; set; }
       string Description { get; set; }

       long Quantity { get; set; }

       decimal Cost();

    }
}
