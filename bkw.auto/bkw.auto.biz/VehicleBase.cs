using bkw.auto.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkw.auto.biz
{
    public abstract class VehicleBase : bkw.auto.interfaces.IVehicle, IValidatableObject
    {
        protected VehicleKind _kind;

        public VehicleBase(VehicleKind kind, string nameStr, string desc)
        {
            _kind = kind;
            Name = nameStr;
            Description = desc;
         
        }

        public string Name { get; private set; }
        public string Description { get; private set; }

        public abstract IVehicleOptionModel DriveTrain { get; }
        public abstract IVehicleOptionModel Interior { get;  }
        public abstract IVehicleOptionModel Exterior { get;  }

        public override string ToString()
        {

            return $"This {Name} is a {Description} that has a {DriveTrain.GetType().Name} (w/{DriveTrain.AvailableOptions.Count()} available options) , {Interior.GetType().Name} (w/{Interior.AvailableOptions.Count()} available options) and {Exterior.GetType().Name} (w/{Exterior.AvailableOptions.Count()} available options)";
        }

        public string ToLongString()
        {

            return $"This {Name} is a {Description} that has a {DriveTrain}, {Interior} and {Exterior}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            List<ValidationResult> _results = new List<ValidationResult>();

            var badDriveTrain = DriveTrain.AvailableOptions.Any(opt => !opt.CompatibileKinds.HasFlag(_kind));

            var badInterior = Interior.AvailableOptions.Any(opt => !opt.CompatibileKinds.HasFlag(_kind));

            var badExterior = Exterior.AvailableOptions.Any(opt => !opt.CompatibileKinds.HasFlag(_kind));

            if (badDriveTrain)
            {
                var badDTOs = DriveTrain.AvailableOptions
                                .Where(opt => !opt.CompatibileKinds.HasFlag(_kind))
                                .Select(opt => opt.Description).ToArray();
                
                
                _results.Add(new ValidationResult($"Invalid Drive Train Options: {String.Join(", ", badDTOs)}", new string[] {"DriveTrain"}));
            }

            if (badInterior)
            {
                var badInteriors = Interior.AvailableOptions
                                .Where(opt => !opt.CompatibileKinds.HasFlag(_kind))
                                .Select(opt => opt.Description).ToArray();

                _results.Add(new ValidationResult($"Invalid Interior Options: {String.Join(", ", badInteriors)}", new string[] { "Interior" }));
            }

            if (badExterior)
            {

                var badExteriors = Exterior.AvailableOptions
                               .Where(opt => !opt.CompatibileKinds.HasFlag(_kind))
                               .Select(opt => opt.Description).ToArray();

                _results.Add(new ValidationResult($"Invalid Exterior Options: {String.Join(", ", badExteriors)}", new string[] { "Exterior" }));
            }

            return _results;
        }
    }
}
