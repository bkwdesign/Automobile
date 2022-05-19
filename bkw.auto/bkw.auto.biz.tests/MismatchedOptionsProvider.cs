using bkw.auto.biz.drivetrains;
using bkw.auto.biz.exterior;
using bkw.auto.biz.interior;
using bkw.auto.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bkw.auto.biz.tests
{
    internal class MismatchedOptionsProvider : bkw.auto.interfaces.IVehicleOptionsProvider
    {
        public IEnumerable<IVehicleOption> GetVehicleOptions(VehicleKind kind)
        {

            IVehicleOptionsProvider p1 = new BadDriveTrainOptionsProvider();
            IVehicleOptionsProvider p2 = new InteriorOptionsProvider();
            IVehicleOptionsProvider p3 = new ExteriorOptionsProvider();

            var opts1 = p1.GetVehicleOptions(kind);
            var opts2 = p2.GetVehicleOptions(kind);
            var opts3 = p3.GetVehicleOptions(kind);

            return opts1.Concat(opts2).Concat(opts3);

        }

        #region helper provider classes
        class BadDriveTrainOptionsProvider : IVehicleOptionsProvider
        {
            IEnumerable<IVehicleOption> IVehicleOptionsProvider.GetVehicleOptions(VehicleKind kind)
            {
                var options = new List<DriveTrainOption>();

                //load drive train overall-arrangement
                switch (kind)
                {
                    case VehicleKind.EconomyCar:
                        options.Add(new DriveTrainOption { Brand = "Ford", Name = "DriveType", Description = "Front Wheel Drive", Quantity = 1, CompatibileKinds=VehicleKind.SportsCar });
                        options.Add(new DriveTrainOption { Brand = "Ford", Name = "DriveType", Description = "Rear Wheel Drive", Quantity = 1 , CompatibileKinds=VehicleKind.SportsCar});
                        break;
                    case VehicleKind.SportsCar:
                        options.Add(new DriveTrainOption { Brand = "Mercury", Name = "DriveType", Description = "Four Wheel Drive", Quantity = 1 , CompatibileKinds=VehicleKind.TruckCommercial});
                        options.Add(new DriveTrainOption { Brand = "Mercury", Name = "DriveType", Description = "Rear Wheel Drive", Quantity = 1 , CompatibileKinds=VehicleKind.TruckCommercial});
                        break;
                    case VehicleKind.TruckCommercial:
                        options.Add(new DriveTrainOption { Brand = "Ford", Name = "DriveType", Description = "Rear Wheel Drive", Quantity = 1 , CompatibileKinds=VehicleKind.SportsCar});
                        break;
                    case VehicleKind.TruckPickup:
                        options.Add(new DriveTrainOption { Brand = "Ford", Name = "DriveType", Description = "All Wheel Drive", Quantity = 1 , CompatibileKinds=VehicleKind.SportsCar});
                        options.Add(new DriveTrainOption { Brand = "Ford", Name = "DriveType", Description = "Front Wheel Drive", Quantity = 1, CompatibileKinds=VehicleKind.SportsCar });
                        options.Add(new DriveTrainOption { Brand = "Ford", Name = "DriveType", Description = "Rear Wheel Drive", Quantity = 1 , CompatibileKinds=VehicleKind.SportsCar});
                        break;
                }

                //load tire options
                switch (kind)
                {
                    case VehicleKind.EconomyCar:
                    case VehicleKind.TruckPickup:
                        options.Add(new DriveTrainOption { Brand = "Michelin", Name = "Tire", Description = "All Weather Radial", Quantity = 4, CompatibileKinds = VehicleKind.EconomyCar | VehicleKind.TruckPickup });
                        options.Add(new DriveTrainOption { Brand = "Michelin", Name = "Tire", Description = "All Weather Radial - Whitewall", Quantity = 4, CompatibileKinds = VehicleKind.EconomyCar | VehicleKind.TruckPickup });
                        break;
                    case VehicleKind.SportsCar:
                        options.Add(new DriveTrainOption { Brand = "Goodyear", Name = "Tire", Description = "Run Flat - Large Hub Package", Quantity = 4, CompatibileKinds = VehicleKind.SportsCar });
                        options.Add(new DriveTrainOption { Brand = "Goodyear", Name = "Tire", Description = "Advanced Performance - Sport Hub Package", Quantity = 4, CompatibileKinds = VehicleKind.SportsCar });
                        break;
                    case VehicleKind.TruckCommercial:
                        options.Add(new DriveTrainOption { Brand = "Firestone", Name = "Tire", Description = "Standard Long-Road Truck Tire", Quantity = 4, CompatibileKinds = VehicleKind.TruckCommercial });
                        break;
                }

                return options;
            }
        }
        class ExteriorOptionsProvider : IVehicleOptionsProvider
        {
            IEnumerable<IVehicleOption> IVehicleOptionsProvider.GetVehicleOptions(VehicleKind kind)
            {
                var options = new List<ExteriorOption>();

                switch (kind)
                {
                    case VehicleKind.EconomyCar:
                        options.Add(new ExteriorOption { Name = "Color", Brand = "Ford", Description = "Plain Red", Quantity = 1, CompatibileKinds = VehicleKind.EconomyCar });
                        options.Add(new ExteriorOption { Name = "Color", Brand = "Ford", Description = "Powder White", Quantity = 1, CompatibileKinds = VehicleKind.EconomyCar });
                        break;
                    case VehicleKind.SportsCar:
                        options.Add(new ExteriorOption { Name = "Color", Brand = "Ford", Description = "Fire Red", Quantity = 1, CompatibileKinds = VehicleKind.SportsCar });
                        options.Add(new ExteriorOption { Name = "Color", Brand = "Ford", Description = "Stealth Black", Quantity = 1, CompatibileKinds = VehicleKind.SportsCar });
                        break;
                    case VehicleKind.TruckCommercial:
                        options.Add(new ExteriorOption { Name = "Color", Brand = "Ford", Description = "Enconoline White", Quantity = 1, CompatibileKinds = VehicleKind.TruckCommercial });
                        options.Add(new ExteriorOption { Name = "Color", Brand = "Ford", Description = "Enconoline BabyBlue", Quantity = 1, CompatibileKinds = VehicleKind.TruckCommercial });
                        break;
                    case VehicleKind.TruckPickup:
                        options.Add(new ExteriorOption { Name = "Color", Brand = "Ford", Description = "Yellow", Quantity = 1, CompatibileKinds = VehicleKind.TruckPickup });
                        options.Add(new ExteriorOption { Name = "Color", Brand = "Ford", Description = "Kelley Green", Quantity = 1, CompatibileKinds = VehicleKind.TruckPickup });
                        break;
                }

                switch (kind)
                {
                    case VehicleKind.EconomyCar:
                        options.Add(new ExteriorOption { Name = "Towing", Brand = "--", Description = "(NONE OFFERED)", Quantity = 0 });
                        options.Add(new ExteriorOption { Name = "LuggageRack", Brand = "--", Description = "(NONE OFFERED)", Quantity = 1 });
                        break;
                    case VehicleKind.SportsCar:
                        options.Add(new ExteriorOption { Name = "Towing", Brand = "--", Description = "(NONE OFFERED)", Quantity = 0 });
                        options.Add(new ExteriorOption { Name = "LuggageRack", Brand = "Ford", Description = "Light Duty Rack", Quantity = 1 });
                        break;
                    case VehicleKind.TruckCommercial:
                        options.Add(new ExteriorOption { Name = "Towing", Brand = "Ford", Description = "2 inch ball", Quantity = 1 });
                        options.Add(new ExteriorOption { Name = "Towing", Brand = "Ford", Description = "Sway Bar w/ball", Quantity = 1 });
                        options.Add(new ExteriorOption { Name = "LuggageRack", Brand = "--", Description = "(NONE OFFERED)", Quantity = 0 });
                        break;
                    case VehicleKind.TruckPickup:
                        options.Add(new ExteriorOption { Name = "Towing", Brand = "Ford", Description = "2 inch ball", Quantity = 1 });
                        options.Add(new ExteriorOption { Name = "Towing", Brand = "Ford", Description = "Sway Bar w/ball", Quantity = 1 });
                        options.Add(new ExteriorOption { Name = "LuggageRack", Brand = "Ford", Description = "Heavy Duty Rack", Quantity = 1 });
                        break;
                }

                return options;
            }
        }
        class InteriorOptionsProvider : IVehicleOptionsProvider
        {
            IEnumerable<IVehicleOption> IVehicleOptionsProvider.GetVehicleOptions(VehicleKind kind)
            {
                var options = new List<InteriorOption>();

                //add seat options
                switch (kind)
                {
                    case VehicleKind.EconomyCar:
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Ford", Description = "Vinyl-Bucket", Quantity = 1 });
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Ford", Description = "Vinyl-Standard", Quantity = 1 });
                        break;
                    case VehicleKind.SportsCar:
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Mercury", Description = "Suede", Quantity = 1 });
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Mercury", Description = "Leather", Quantity = 1 });
                        break;
                    case VehicleKind.TruckCommercial:
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Ford", Description = "Vinyl", Quantity = 1 });
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Ford", Description = "Suede", Quantity = 1 });
                        break;
                    case VehicleKind.TruckPickup:
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Ford", Description = "Vinyl", Quantity = 1 });
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Ford", Description = "Leather", Quantity = 1 });
                        options.Add(new InteriorOption { Name = "Seats", Brand = "Ford", Description = "Suede", Quantity = 1 });
                        break;
                }

                //add A/C options
                switch (kind)
                {
                    case VehicleKind.EconomyCar:
                    case VehicleKind.TruckPickup:
                        options.Add(new InteriorOption { Name = "A/C", Brand = "AC Delco", Description = "Single Temp Dash Control", Quantity = 1 });
                        break;
                    case VehicleKind.SportsCar:
                        options.Add(new InteriorOption { Name = "A/C", Brand = "Mercury", Description = "Dual Temp Dash Control", Quantity = 1 });
                        options.Add(new InteriorOption { Name = "A/C", Brand = "Mercury", Description = "Dual Temp Touchscreen Control", Quantity = 1 });
                        break;
                    case VehicleKind.TruckCommercial:
                        options.Add(new InteriorOption { Name = "A/C", Brand = "AC Delco", Description = "Full Cab - Dash Control", Quantity = 1 });
                        options.Add(new InteriorOption { Name = "A/C", Brand = "Mack Enterprises", Description = "Touchscreen Control", Quantity = 1 });
                        break;
                }

                return options;
            }
        }
        #endregion
    }
}