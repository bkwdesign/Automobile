using bkw.auto.interfaces;


namespace bkw.auto.biz.drivetrains
{
    class HeavyDriveTrain : BaseOptionModel<DriveTrainOption>, interfaces.IVehicleOptionModel
    {


        #region ctor
        public HeavyDriveTrain()
        {
            base._requirements = new string[] { "DriveType", "Tire","Transmission"};

        }
        #endregion

        public IEnumerable<IVehicleOption> AvailableOptions { get => _availableOpts; }
        public IEnumerable<IVehicleOption> SelectedOptions { get => _selectedOpts; set => _selectedOpts = (List<DriveTrainOption>)value; }
    }

}
