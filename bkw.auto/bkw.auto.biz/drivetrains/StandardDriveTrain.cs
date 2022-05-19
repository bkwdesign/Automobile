using bkw.auto.interfaces;


namespace bkw.auto.biz.drivetrains
{
    public class StandardDriveTrain : BaseOptionModel<DriveTrainOption>, interfaces.IVehicleOptionModel
    {

        #region ctor
        public StandardDriveTrain()
        {
            base._requirements = new string[] { "DriveType", "Tire" };    
        }
        #endregion

        public IEnumerable<IVehicleOption> AvailableOptions { get => _availableOpts;}
        public IEnumerable<IVehicleOption> SelectedOptions { get => _selectedOpts; set => _selectedOpts = (List<DriveTrainOption>)value; }

       
    }
}
