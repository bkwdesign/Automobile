using bkw.auto.interfaces;

namespace bkw.auto.biz.exterior
{
    public class AftermarketExterior : BaseOptionModel<ExteriorOption>, interfaces.IVehicleOptionModel
    {
    
        #region ctor
        public AftermarketExterior()
        {
            base._requirements = new string[] { "Color","LuggageRack","Towing" };


        }
        #endregion


        public IEnumerable<IVehicleOption> AvailableOptions { get => _availableOpts; }
        public IEnumerable<IVehicleOption> SelectedOptions { get => _selectedOpts; set => _selectedOpts = (List<ExteriorOption>)value; }

 
    }
}
