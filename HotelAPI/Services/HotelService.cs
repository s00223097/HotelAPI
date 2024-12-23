using HotelAPI.Models;
using HotelAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelAPI.Services
{
    public class HotelService : IHotelService
    {
        // Repository for accessing hotel data
        private readonly IHotelRepository _hotelRepository;

        // Constructor - injects hotel repository dependency
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        // Gets all hotels from the repository
        public IEnumerable<Hotel> GetAllHotels()
        {
            return _hotelRepository.GetAllHotels();
        }

        // Gets a specific hotel by its ID
        public Hotel GetHotelById(int id)
        {
            return _hotelRepository.GetHotelById(id);
        }

        // Asynchronously gets all hotels from the repository
        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return await _hotelRepository.GetAllHotelsAsync();
        }
    }
}
