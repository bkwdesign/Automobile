namespace bkw.auto.interfaces
{
    public interface IVehicle
    {
        string Name { get; }

        string Description { get; }

        IVehicleOptionModel DriveTrain { get; }

        IVehicleOptionModel Interior { get; }

        IVehicleOptionModel Exterior { get; }

        public string ToLongString();
    }
}