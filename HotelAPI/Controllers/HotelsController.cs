using HotelAPI.Services;
using HotelAPI.Utilties;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelsController()
        {
            _hotelService = new HotelService();
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
            try
            {
                var hotel = _hotelService.GetHotelById(hotelId);
                if (hotel == null)
                    return NotFound(new ErrorResponse($"Hotel with id {hotelId} not found"));

                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse($"Couldn't retrieve hotel id {hotelId}", ex.Message));
            }
        }
    }
}
