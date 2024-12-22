using HotelAPI.Models;
using System.Text.Json;

namespace HotelAPI.Services
{
    public class HotelService : IHotelService
    {
        // private List of hotels of type Hotel
        private readonly List<Hotel> _hotels;
        public HotelService()
        {
            try
            {
                var jsonData = File.ReadAllText("hotels.json"); // read the json file
                // Parse the json data and store it in the _hotels list
                _hotels = JsonSerializer.Deserialize<List<Hotel>>(jsonData) ?? new List<Hotel>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading hotel data - couldn't read hotels in from the json file.", ex);
            }
        }
        /// <summary>
        /// Method to get all hotels.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Hotel> GetAllHotels() => _hotels;

        /// <summary>
        /// LINQ Query method to get a hotel by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Hotel GetHotelById(int id)
        {
            return _hotels.FirstOrDefault(h => h.Id == id);
        }

        /// <summary>
        /// Method to implement GetAllHotelsAsync() as in: almost in parallel
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            return Task.FromResult(GetAllHotels());
        }
    }
}
