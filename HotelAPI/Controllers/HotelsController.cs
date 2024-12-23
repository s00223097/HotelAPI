using HotelAPI.Models;
using HotelAPI.Services;
using HotelAPI.Utilties;
using HotelAPI.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FluentValidation;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase // derive from the base class because we get views too
    {
        // Private fields
        private readonly ILogger<HotelsController> _logger; // for logging events, errors etc.
        private readonly IHotelService _hotelService; // instantiate an instance of the hotel service
        private readonly IValidator<int> _idValidator;

        public HotelsController(IHotelService hotelService, ILogger<HotelsController> logger, IValidator<int> idValidator)
        {
            // Dependency injection - inject the hotel service into the controller
            _hotelService = hotelService;
            _logger = logger;
            _idValidator = idValidator;
        }

        [HttpGet]
        public IActionResult GetAllHotels()
        {
            try
            {
                var hotels = _hotelService.GetAllHotels(); // get all the hotels from the json file
                return Ok(hotels); // return the hotels as a json object
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching all hotels");
                return StatusCode(500, new ErrorResponse("Couldn't return all the hotels from the json file.", ex.Message)); 
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                _logger.LogInformation($"Fetching details for hotel ID: {id}...");

                // Validate the hotel ID
                var validationResult = _idValidator.Validate(id);
                if (!validationResult.IsValid) {
                    _logger.LogWarning($"Validation failed for hotel ID: {id}. Errors: {string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))}");
                    return BadRequest(new ErrorResponse("Validation failed", string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage))));
                }

                Hotel hotel = _hotelService.GetHotelById(id);
                if (hotel == null)
                {
                    _logger.LogWarning($"Hotel with ID {id} not found");
                    return NotFound(new ErrorResponse($"Hotel Id {id} not found"));
                }

                _logger.LogInformation($"Successfully fetched details for hotel ID: {id}");
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching details for hotel ID: {id}");
                return StatusCode(500, new ErrorResponse("An unexpected error occurred - see logs for details.", ex.Message));
            }
        }
    }
}
