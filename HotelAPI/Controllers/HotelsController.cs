using HotelAPI.Services;
using HotelAPI.Utilties;
using HotelAPI.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase // derive from the base class because we get views too
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            try
            {
                var hotels = _hotelService.GetAllHotels();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse("Couldn't return all the hotels from the json file.", ex.Message));
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int hotelId)
        {
            ILogger.LogInformation($"Fetching details for hotel ID: {hotelId}");

            var validator = new HotelIdValidator();
            var result = validator.Validate(hotelId);

            if (!result.IsValid)
                return BadRequest(new ErrorResponse("Validation failed", string.Join("; ", result.Errors.Select(e => e.ErrorMessage))));

            var hotel = _hotelService.GetHotelById(hotelId);
            if (hotel == null)
                return NotFound(new ErrorResponse($"Hotel Id {hotelId} not found"));

            return Ok(hotel);
        }
    }
}
