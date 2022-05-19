using bkw.auto.biz;
using bkw.auto.interfaces;
using System.ComponentModel.DataAnnotations;

namespace bkw.auto.api.Models
{
    /// <summary>
    /// this validatable object should give feedback via the WebAPI if selected options were valid for the type of car
    /// </summary>
    public class UserSubmittedVehicle :IValidatableObject
    {
        /// <summary>
        /// this provider will iterate through the submitted bound-model, creating a normal business object in QuotableVehicle
        /// </summary>
        private UserSubmittedOptionsProvider _optionsProvider;

        /// <summary>
        /// this QuotableVehicle property is populated during the IValidatableObject call, during model binding
        /// </summary>
        public IVehicle? QuotableVehicle;

        public UserSubmittedVehicle()
        {

            this.Name = "User Submitted Vehicle";
            this.Description = "User Submitted Options";
            this.DriveTrain = new UserOptionModel();
            this.Exterior = new UserOptionModel();
            this.Interior = new UserOptionModel();

            _optionsProvider = new UserSubmittedOptionsProvider();
        }
        public VehicleKind VehicleKind { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public UserOptionModel DriveTrain { get; set; }

        public UserOptionModel Interior { get; set; }

        public UserOptionModel Exterior { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {               
           List<ValidationResult> results = new List<ValidationResult>();

            _optionsProvider.BuildOptionsFromUserSubmission(this);

            switch (this.VehicleKind)
            {
                case VehicleKind.EconomyCar:
                    QuotableVehicle = EconomyCar.BuildCar($"{this.Name} Customized", _optionsProvider);
                    break;
                case VehicleKind.SportsCar:
                    QuotableVehicle = SportsCar.BuildCar($"{this.Name} Customized", _optionsProvider);
                    break;
                case VehicleKind.TruckCommercial:
                    QuotableVehicle = TruckCommercial.BuildCar($"{this.Name} Customized", _optionsProvider);
                    break;
                case VehicleKind.TruckPickup:
                    QuotableVehicle = TruckPickup.BuildCar($"{this.Name} Customized", _optionsProvider);
                    break;
            }

            if(QuotableVehicle is IValidatableObject)
            {
                var vehicleValiationResults = ((IValidatableObject)QuotableVehicle).Validate(validationContext);

                foreach(var err in vehicleValiationResults)
                {
                    results.Add(err);
                }
            }

            return results; 
        }


    }
}
