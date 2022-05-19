using bkw.auto.interfaces;

namespace bkw.auto.biz.interior
{
    class DeluxeInterior : BaseOptionModel<InteriorOption>, interfaces.IVehicleOptionModel
    {
        
        #region ctor
        public DeluxeInterior()
        {
            base._requirements = new string[] { "A/C", "Seats" };

        }
        #endregion
        public IEnumerable<IVehicleOption> AvailableOptions { get => _availableOpts; }
        public IEnumerable<IVehicleOption> SelectedOptions { get => _selectedOpts; set => _selectedOpts = (List<InteriorOption>)value; }


    }

}
