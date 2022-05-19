using bkw.auto.interfaces;


namespace bkw.auto.biz.exterior
{
    internal class FactoryExterior : BaseOptionModel<ExteriorOption>, interfaces.IVehicleOptionModel
    { 

        #region ctor
        public FactoryExterior()
        {
            base._requirements = new string[] { "Color" };

        }
        #endregion
        public IEnumerable<IVehicleOption> AvailableOptions { get => _availableOpts; }
        public IEnumerable<IVehicleOption> SelectedOptions { get => _selectedOpts; set => _selectedOpts = (List<ExteriorOption>)value; }

    }
}
