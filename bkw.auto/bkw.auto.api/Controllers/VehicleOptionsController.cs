using Microsoft.AspNetCore.Mvc;
using bkw.auto.biz;
using bkw.auto.interfaces;

namespace bkw.auto.api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VehicleOptionsController : ControllerBase
    {

        private readonly ILogger<VehicleOptionsController> _logger;
        private IVehicleOptionsProvider _vehicleOptionsProvider;

        public VehicleOptionsController(ILogger<VehicleOptionsController> logger, IVehicleOptionsProvider vehicleOptions)
        {
            _logger = logger;
            _vehicleOptionsProvider = vehicleOptions;
        }

        // GET: api/<VehicleOptionsController>
        [HttpGet]
        public IEnumerable<IVehicleOption> Get(VehicleKind kind)
        {
            return _vehicleOptionsProvider.GetVehicleOptions(kind);
        }

   


    }
}
