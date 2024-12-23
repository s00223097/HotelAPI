﻿using HotelAPI.Models;
using HotelAPI.Services;
using HotelAPI.Utilties;
using HotelAPI.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase // derive from the base class because we get views too
    {
        private readonly ILogger<HotelController> _logger; // for logging events, errors etc.
        private readonly IHotelService _hotelService; // instantiate an instance of the hotel service

        public HotelController(IHotelService hotelService, ILogger<HotelController> logger)
        {
            // Dependency injection - inject the hotel service into the controller
            _hotelService = hotelService;
            _logger = logger;
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
        public IActionResult GetHotelById(int hotelId)
        {
            try
            {
                _logger.LogInformation($"Fetching details for hotel ID: {hotelId}...");

                // Validate the hotel ID
                HotelIdValidator validator = new HotelIdValidator();
                var result = validator.Validate(hotelId);

                if (!result.IsValid)
                    return BadRequest(new ErrorResponse("Validation failed", string.Join("; ", result.Errors.Select(e => e.ErrorMessage))));

                Hotel hotel = _hotelService.GetHotelById(hotelId);
                if (hotel == null)
                {
                    _logger.LogWarning($"Hotel with ID {hotelId} not found");
                    return NotFound(new ErrorResponse($"Hotel Id {hotelId} not found"));
                }

                _logger.LogInformation($"Successfully fetched details for hotel ID: {hotelId}");
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while fetching details for hotel ID: {hotelId}");
                return StatusCode(500, new ErrorResponse("An unexpected error occurred - see logs for details.", ex.Message));
            }
        }
    }
}
