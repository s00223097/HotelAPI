using HotelAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelAPI.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        // In-memory collection of hotels
        private readonly List<Hotel> _hotels;

        public HotelRepository()
        {
            // Initialize with some data or load from a data source
            _hotels = new List<Hotel>
            {
                // Example data
                new Hotel { Id = 1, Name = "Seaside Paradise", Location = "Maldives", Rating = 4.9, ImageUrl = "https://example.com/images/seaside-paradise.jpg", DatesOfTravel = new List<string> { "2024-01-01", "2024-01-07" }, BoardBasis = "All Inclusive", Rooms = new List<Room> { new Room { RoomType = "Deluxe Suite", Amount = 5 } } }
                // Add more hotels as needed
            };
        }

        // Returns all hotels in the repository
        public IEnumerable<Hotel> GetAllHotels()
        {
            return _hotels;
        }

        // Finds and returns a hotel by its ID, or null if not found
        public Hotel GetHotelById(int id)
        {
            // return the first hotel with the matching ID, or null if no match is found
            return _hotels.FirstOrDefault(h => h.Id == id); 
        }

        // Asynchronously retrieves all hotels
        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            // Example implementation using an asynchronous database call
            return await Task.Run(() => GetAllHotels());
        }
    }
} 