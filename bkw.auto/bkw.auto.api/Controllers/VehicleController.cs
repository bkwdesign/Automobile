using bkw.auto.interfaces;
using bkw.auto.biz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bkw.auto.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        // GET: api/<VehicleController>
        private readonly ILogger<VehicleOptionsController> _logger;
        private IVehicleOptionsProvider _vehicleOptionsProvider;

        public VehicleController(ILogger<VehicleOptionsController> logger, IVehicleOptionsProvider vehicleOptions)
        {
            _logger = logger;
            _vehicleOptionsProvider = vehicleOptions;
        }

        // GET: api/<VehicleController>
        [HttpGet]
        public ActionResult<IVehicle> Get(VehicleKind kind)
        {
            IVehicle vehicle = null;

            switch (kind)
            {
                case VehicleKind.EconomyCar:
                    vehicle = EconomyCar.BuildCar("Ford Escape", _vehicleOptionsProvider);
                    break;
                case VehicleKind.SportsCar:
                    vehicle = SportsCar.BuildCar("Ford Mustang", _vehicleOptionsProvider);
                    break;
                case VehicleKind.TruckCommercial:
                    vehicle = TruckCommercial.BuildCar("Econoline Van", _vehicleOptionsProvider);
                    break;
                case VehicleKind.TruckPickup:
                    vehicle = TruckPickup.BuildCar("Ford F-150", _vehicleOptionsProvider);
                    break;
                default:
                    return BadRequest();
            }
            return Ok(vehicle);
        }

        /// <summary>
        /// Validate a list of options as being valid for a kind of car or not
        /// </summary>
        /// <param name="kind"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ValidateVehicle(VehicleKind kind, Models.UserSubmittedVehicle userSubmittedVehicle)
        {
            if(kind != userSubmittedVehicle.VehicleKind)
            {
                ModelState.AddModelError("kind", $"The URL parameter denotes {kind} but the model you submitted is {userSubmittedVehicle.VehicleKind}");
            }

            if (ModelState.IsValid)
            {
                //good place to save QuotableVehicle into a document database
                //send an email to dealer, etc.
                return Ok(userSubmittedVehicle.QuotableVehicle);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
