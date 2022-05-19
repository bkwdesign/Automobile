using bkw.auto.interfaces;

namespace bkw.auto.api.Models
{
    /// <summary>
    /// When the user posts JSON to the API, the bound-object is passed into this to re-create strongly-typed list of options that will properly be sorted by 
    /// </summary>
    public class UserSubmittedOptionsProvider : bkw.auto.interfaces.IVehicleOptionsProvider
    {
        List<IVehicleOption> options = new List<IVehicleOption>();

        public void BuildOptionsFromUserSubmission(UserSubmittedVehicle userSubmittedVehicle)
        {
            foreach (IVehicleOption opt in userSubmittedVehicle.DriveTrain.AvailableOptions)
            {
                options.Add(new bkw.auto.biz.drivetrains.DriveTrainOption { Brand = opt.Brand, Description = opt.Description, Name = opt.Name, Quantity = opt.Quantity, CompatibileKinds=opt.CompatibileKinds });
            }

            foreach (IVehicleOption opt in userSubmittedVehicle.Interior.AvailableOptions)
            {
                options.Add(new bkw.auto.biz.interior.InteriorOption { Brand = opt.Brand, Description = opt.Description, Name = opt.Name, Quantity = opt.Quantity, CompatibileKinds=opt.CompatibileKinds });
            }

            foreach (IVehicleOption opt in userSubmittedVehicle.Exterior.AvailableOptions)
            {
                options.Add(new bkw.auto.biz.exterior.ExteriorOption { Brand = opt.Brand, Description = opt.Description, Name = opt.Name, Quantity = opt.Quantity, CompatibileKinds=opt.CompatibileKinds });
            }
        }

        public IEnumerable<IVehicleOption> GetVehicleOptions(VehicleKind kind)
        {
            return options;
        }
    }
}
