using bkw.auto.interfaces;

namespace bkw.auto.api.Models
{
    public class UserOptionModel : bkw.auto.biz.BaseOptionModel<UserOption>
    {
        #region ctor
        public UserOptionModel()
        {
           // base._requirements = new string[] { "Color", "LuggageRack", "Towing","Tire", "DriveType", "Tire", "Transmission", "A/C", "Seats" };
        }
        #endregion


        public List<UserOption> AvailableOptions { get => _availableOpts; set => _availableOpts=value; }
        public List<UserOption> SelectedOptions { get => _selectedOpts; set => _selectedOpts = value;}
    }
}
