using HotelAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace HotelAPI.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        // List to store hotels in memory
        private readonly List<Hotel> _hotels = new List<Hotel>();
        // Path to JSON file containing hotel data - file in the project folder
        private readonly string _filePath = "hotels.json";
        

        // Constructor - loads hotels from JSON file when repository is created
        public HotelRepository()
        {
            try
            {
                // Read JSON file contents
                var json = File.ReadAllText(_filePath);
                Console.WriteLine("JSON Content: " + json); // for debugging

                // Deserialize JSON to list of hotels with case-insensitive option
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var hotels = JsonSerializer.Deserialize<List<Hotel>>(json, options);
                if (hotels != null)
                {
                    _hotels = hotels;
                }
                else
                {
                    Console.WriteLine("Deserialization resulted in null.");
                }
            }
            catch (Exception ex)
            {
                // Log any errors that occur during file loading 
                Console.WriteLine($"Error loading hotels: {ex.Message}");
            }
        }

        // Get all hotels from the repository
        public IEnumerable<Hotel> GetAllHotels()
        {
            Console.WriteLine($"Total hotels in repository: {_hotels.Count}"); // Debugging
            return _hotels;
        }

        // Get a single hotel by its ID
        public Hotel GetHotelById(int id)
        {
            // return the first hotel with the matching ID, or null if no match is found
            return _hotels.FirstOrDefault(h => h.Id == id);  
        }

        // Get all hotels asynchronously
        public async Task<IEnumerable<Hotel>> GetAllHotelsAsync()
        {
            // Simulates async database call using Task.Run -> more for a real database
            return await Task.Run(() => GetAllHotels());
        }
    }
} 