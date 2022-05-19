namespace bkw.auto.interfaces
{
    public interface IVehicleOptionModel
    {
        /// <summary>
        /// selected options are completed when one of each required selections have been made
        /// </summary>
        String[] Requirements { get;}

        IEnumerable<IVehicleOption> AvailableOptions { get; }

        IEnumerable<IVehicleOption> SelectedOptions { get; set; }

        public void LoadOptions(IEnumerable<IVehicleOption> opts);
    }
}
